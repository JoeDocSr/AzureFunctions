using Empower.DataAccess.ApplicationContext.Empower;
using Empower.DataAccess.Entities.Empower;
using Empower.DataAccess.Entities.Eviti;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmpowerEligiblePatients
{
    internal class ProcessData
    {
        private static EmpowerContext _empowerContext = new EmpowerContext();

        private List<EligiblePatient> listOfEligiblePatients = new List<EligiblePatient>();

        public void ProcessPatients(List<evitiEligiblePatients> listOfPatients, List<DataTag> lstOfDataTags, EmpowerContext _context, ILogger log)
        {
            _empowerContext = _context;
            int outerCntr = 0;
            int innerCntr = 0;

            foreach (var evp in listOfPatients)
            {
                outerCntr += 1;

                foreach (var dtag in lstOfDataTags)
                {
                    bool matchToTag = true;
                    innerCntr += 1;

                    if (dtag.PayerLOBGuid.ToString().Equals(evp.PayerLineOfBusinessGuid.ToString(),StringComparison.OrdinalIgnoreCase))
                    {
                        //Check to see if the Tag has regimen guids.  If the tag has regimen guids then
                        //try to make a match with the Patient Reference Guid.
                        //If it is a match Add to List of jasper patients
                        if (!String.IsNullOrWhiteSpace(dtag.RegimenGuids))
                        {
                            if (dtag.RegimenGuids.Contains(evp.ReferenceGuid.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                AddThisEligiblePatient(evp, dtag.Id,log);
                                //break;
                            }
                        }

                        //Check Tag Cancer Type against the Care Plan Cancer Type
                        if (!dtag.CancerTypeGuid.ToString().Equals(evp.CancerTypeGUID.ToString(), StringComparison.OrdinalIgnoreCase))
                        {
                            matchToTag = false;
                            //break;
                        }

                        //Check Tag paths against the Care Plan Paths
                        if (matchToTag && !string.IsNullOrWhiteSpace(dtag.PathlogyGuids))
                        {
                            if (!dtag.PathlogyGuids.Contains(evp.CancerPathologyGUID.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                matchToTag = false;
                                //break;
                            }
                        }

                        //Check to see if there are any Drugs in the Config and match against Care Plan
                        if (matchToTag && !string.IsNullOrWhiteSpace(dtag.DrugGPIs))
                        {
                            List<string> carePlanDrugs = evp.CarePlanGPIs.Split(";").ToList();
                            Boolean foundMatchingDrug = false;
                            foreach (var cpd in carePlanDrugs)
                            {
                                if (dtag.DrugGPIs.Contains(cpd, StringComparison.OrdinalIgnoreCase))
                                {
                                    foundMatchingDrug = true;
                                    break;
                                }
                            }
                            matchToTag = foundMatchingDrug;

                        }

                        //Check Tag Stages against the Care Plan stage
                        if (matchToTag && !String.IsNullOrWhiteSpace(dtag.StageGuids))
                        {
                            if (!dtag.StageGuids.Contains(evp.CancerStageGUID.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                matchToTag = false;
                                //break;
                            }
                        }

                        //Check Tag Bio markers and values against the Care Plan Bio Makers and values
                        if (matchToTag && !String.IsNullOrWhiteSpace(dtag.BioMarkerAndValueGuids))
                        {
                            if (!string.IsNullOrWhiteSpace(evp.BioMarkerAndValuesGuids))
                            {
                                List<string> cpBioGuids = evp.BioMarkerAndValuesGuids.Split(";").ToList();
                                List<string> tagBioGuids = dtag.BioMarkerAndValueGuids.Split(";").ToList();

                                bool foundMatchingBioMarker = false;

                                foreach (var tbgs in tagBioGuids)
                                {
                                    foreach (var cpgs in cpBioGuids)
                                    {
                                        if (cpgs.Contains(tbgs, StringComparison.OrdinalIgnoreCase))
                                        {
                                            foundMatchingBioMarker = true;
                                            break;
                                        }
                                    }
                                }

                                matchToTag = foundMatchingBioMarker;
                            }
                        }

                        //Check Tag LOTs against the Care Plan LOT
                        if (matchToTag && !String.IsNullOrWhiteSpace(dtag.LineOfTreatmentGuids))
                        {
                            if (!dtag.LineOfTreatmentGuids.Contains(evp.LineOfTreatmentGuid.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                matchToTag = false;
                                //break;
                            }
                        }
                        //Check Tag GOTs against the Care Plan GOTs
                        if (matchToTag && !String.IsNullOrWhiteSpace(dtag.TreatmentGoalGuids))
                        {
                            if (!dtag.TreatmentGoalGuids.Contains(evp.TreatmentGoalGuid.ToString(), StringComparison.OrdinalIgnoreCase))
                            {
                                matchToTag = false;
                                //break;
                            }
                        }
                        //Check Tag Age Ranges against the Care Plan Patient Age
                        if (matchToTag && dtag.PatientAgeGreaterThan.HasValue)
                        {
                            if (evp.PatientAge <= dtag.PatientAgeGreaterThan)
                            {
                                matchToTag = false;
                                //break;
                            }
                        }

                        if (matchToTag && dtag.PatientAgeLessThan.HasValue)
                        {
                            if (evp.PatientAge >= dtag.PatientAgeLessThan)
                            {
                                matchToTag = false;
                                //break;
                            }
                        }

                        if (matchToTag)
                        {
                            AddThisEligiblePatient(evp, dtag.Id,log);
                            break;
                        }

                    }
                }
            }

            if (listOfEligiblePatients.Count > 0)
            {
               log.LogInformation("**** LIST OF ELIGIBLE PATIENTS TO SAVE = {0} ****",listOfEligiblePatients.Count());

                SaveEligiblePatients(log);
                PrepareToPostToClient(log);
            }
            else
            {
               log.LogInformation("**** NO ELIGIBLE PATIENTS FOUND TO SAVE ****");
            }
            

        }

        private void AddThisEligiblePatient(evitiEligiblePatients evp, long tagId, ILogger log)
        {
            //Check to see if the patient was already add.
            //If so, update the list of data tags.
            if (listOfEligiblePatients.Count > 0 && listOfEligiblePatients.Where(p => p.PatientGuid.Equals(evp.PatientGuid)).Any())
            {
                var foundEP = listOfEligiblePatients.Where(p => p.PatientGuid.Equals(evp.PatientGuid)).FirstOrDefault();
                foundEP.TagConfigurationIds += "," + tagId.ToString();

            }
            else //the list is empty or NO Match found. Add the patient to the list.
            {

                EligiblePatient ep = new EligiblePatient();
                ep.BenefitEndDate = evp.EligibilityEndDate;
                ep.BenefitStartDate = evp.EligibilityStartDate;
                ep.CreatedOn = DateTime.Now;
                ep.EmpowerClientId = null;
                ep.PatientGuid = evp.PatientGuid;
                ep.PatientDOB = evp.BirthDate;
                ep.PatientEmail = evp.EmailAddress;
                ep.PatientFirstName = evp.PatientFirstName;
                ep.PatientLastName = evp.PatientLastName;
                ep.PatientPhoneNumber = "NEED TO GET PHOE NUMBER";
                ep.PayerLOBName = evp.PayerLobName;
                ep.PayerName = evp.PayerName;
                ep.SentToClientOn = DateTime.Now;
                ep.SubscriberIdentification = evp.SubscriberInsuredID;
                ep.PatientPhoneNumber = evp.PhoneNumber;
                ep.CarePlanGuid = evp.CarePlanGuid;
                ep.TagConfigurationIds = tagId.ToString();
                ep.IsRegistered = false;
                ep.SentToClientOn = DateTime.Now;
                ep.ModifiedOn = DateTime.Now;
                ep.PatientZipCode = evp.Zipcode;
                ep.PatientGender= evp.Gender;

                listOfEligiblePatients.Add(ep);

            }
        }

        private void SaveEligiblePatients(ILogger log)
        {
            try
            {
                _empowerContext.EligiblePatients.AddRange(listOfEligiblePatients);
                _empowerContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        private void PrepareToPostToClient( ILogger log)
        {
            ProxyEligiblePatients listOfProyEligiblePatients = new ProxyEligiblePatients();

            foreach (var ep in listOfEligiblePatients)
            {
                ProxyPatients pp = new ProxyPatients();

                pp.BenefitEndDate = ep.BenefitEndDate;
                pp.BenefitStartDate = ep.BenefitStartDate;
                pp.Id = ep.Id;
                pp.PatientGender = ep.PatientGender;
                pp.SubscriberIdentification = ep.SubscriberIdentification;
                pp.PatientPhoneNumber = ep.PatientPhoneNumber;
                pp.PatientFirstName = ep.PatientFirstName;
                pp.PatientMiddleInitial = "";
                pp.PatientLastName = ep.PatientLastName;
                pp.PatientDOB = ep.PatientDOB;
                pp.PatientEmail = ep.PatientEmail;
                pp.PatientZipCode = "19103";
                pp.PayerLOBName = ep.PayerLOBName;
                pp.PayerName = ep.PayerName;

                if (listOfProyEligiblePatients.Patients == null)
                {
                    listOfProyEligiblePatients.Patients = new List<ProxyPatients>();
                }
                listOfProyEligiblePatients.Patients.Add(pp);

            }

            SendDataToClient(listOfProyEligiblePatients,log);
        }

        private void SendDataToClient(ProxyEligiblePatients pep, ILogger log)
        {
            PostData postData = new();
            postData.PostToClient(pep, log);
        }
    }

}
