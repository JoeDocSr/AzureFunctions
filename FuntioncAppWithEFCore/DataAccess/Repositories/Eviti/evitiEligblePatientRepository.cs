using Empower.DataAccess.ApplicationContext.Eviti;
using Empower.DataAccess.Entities.Eviti;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Empower.DataAccess.Repositories.Eviti.Interfaces;
using System.Linq.Expressions;
using System.Data;
using System.Collections.Generic;
using System;

namespace Empower.DataAccess.Repositories.Eviti
{
    public class evitiEligblePatientRepository : GenericRepository<evitiEligblePatientRepository>, IEvitiEligblePatientRepository
    {
        private readonly EvitiContext _context;
        public evitiEligblePatientRepository(EvitiContext context): base(context)
        {
            _context = context;
        }

        public void Add(evitiEligiblePatients entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<evitiEligiblePatients> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<evitiEligiblePatients> Find(Expression<Func<evitiEligiblePatients, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<evitiEligiblePatients> GetEvitiEligiblePatients(DateTime fromDate, DateTime toDate)
        {

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = (Microsoft.Data.SqlClient.SqlConnection)_context.Database.GetDbConnection();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetPatientDataForEmpower";

            SqlParameter paramFromDate = new SqlParameter("fromDate", System.Data.SqlDbType.DateTime);
            paramFromDate.SqlValue = fromDate;
            SqlParameter paramToDate = new SqlParameter("toDate", System.Data.SqlDbType.DateTime);
            paramToDate.SqlValue = toDate;

            cmd.Parameters.Add(paramFromDate);
            cmd.Parameters.Add(paramToDate);
            cmd.Connection.Open();

            SqlDataReader dataReader= cmd.ExecuteReader(CommandBehavior.CloseConnection);

            return GetDataFromReader(dataReader);


            //SqlParameterCollection paramObj; // = new SqlParameterCollection
            //paramObj.Add(paramFromDate);
            //paramObj.Add(paramToDate);


            //SqlParameter[] paramObj = {
            //    new SqlParameter("@toDate", fromDate     ),
            //    new SqlParameter("@toDate", toDate)
            //    };
            ////return (IEnumerable<evitiEligiblePatients>)_context.Database.SqlQueryRaw<evitiEligiblePatients>("GetPatientDataForEmpower ", paramObj);

            //return _context.evitiEligiblePatients.FromSql<evitiEligiblePatients>($"EXECUTE GetPatientDataForEmpower ").ToList();

            //return _context.Database.SqlQueryRaw<evitiEligiblePatients>("GetPatientDataForEmpower ", paramObj).ToList();

        }

        private List<evitiEligiblePatients> GetDataFromReader(SqlDataReader dr)
        {
            List<evitiEligiblePatients> listOfPatients = new List<evitiEligiblePatients>();
            
            while (dr.Read())
            {
                evitiEligiblePatients eep = new evitiEligiblePatients();
                
                eep.PatientGuid = new Guid(IsDBNull(dr, "PatientGuid"));               
                eep.ProviderGuid = new Guid(IsDBNull(dr, "ProviderGuid"));                
                eep.PayerName = IsDBNull(dr, "PayerName");              
                eep.PayerGuid = new Guid(IsDBNull(dr, "PayerGuid"));
                eep.PayerLobName = IsDBNull(dr, "PayerLobName");
                eep.PayerLineOfBusinessGuid = new Guid(IsDBNull(dr, "PayerLineOfBusinessGuid"));
                eep.DiagnosisGuid = new Guid(IsDBNull(dr, "DiagnosisGuid"));
                eep.CarePlanGuid = new Guid(IsDBNull(dr, "CarePlanGuid"));
                eep.PatientName = IsDBNull(dr, "PatientName");
                eep.PatientAge = (int)dr["PatientAge"];
                eep.Gender = IsDBNull(dr,"Gender");
                eep.EmailAddress = IsDBNull(dr, "EmailAddress");
                eep.CancerType = IsDBNull(dr, "CancerType");
                eep.CancerTypeGUID = new Guid(IsDBNull(dr, "CancerTypeGUID"));
                eep.CancerPathologyGUID = new Guid(IsDBNull(dr, "CancerPathologyGUID"));
                eep.CancerStageGUID = new Guid(IsDBNull(dr, "CancerStageGUID"));
                eep.CarePlanName = IsDBNull(dr, "CarePlanName");
                eep.LineOfTreatmentGuid = new Guid(IsDBNull(dr, "LineOfTreatmentGuid"));
                eep.TreatmentGoalGuid = new Guid(IsDBNull(dr, "TreatmentGoalGuid"));
                eep.CarePlanGPIs = IsDBNull(dr, "CarePlanGPIs");
                eep.ReferenceGuid = new Guid(IsDBNull(dr, "ReferenceGuid"));
                eep.BirthDate = IsDBNull(dr, "BirthDate","d");
                eep.EligibilityStartDate = IsDBNull(dr, "EligibilityStartDate","d");
                eep.EligibilityEndDate = IsDBNull(dr, "EligibilityStartDate","d");
                eep.SubscriberInsuredID = IsDBNull(dr, "SubscriberInsuredID");
                eep.PatientFirstName = IsDBNull(dr, "PatientFirstName");
                eep.PatientMiddleName = IsDBNull(dr, "PatientMiddleName");
                eep.PatientLastName = IsDBNull(dr, "PatientLastName");
                eep.PhoneNumber = IsDBNull(dr, "PhoneNumber");
                eep.Zipcode = IsDBNull(dr, "ZipCode");
                eep.BioMarkerAndValuesGuids = IsDBNull(dr, "BioMarkerAndValuesGuids");
                eep.LineOfTreatment = IsDBNull(dr, "LineOfTreatment");
                eep.TreatmentGoal = IsDBNull(dr, "TreatmentGoal");

                listOfPatients.Add(eep);
            }

            return listOfPatients;
        }

        private static string IsDBNull(SqlDataReader dataReader, string columnName)
        {
            if(dataReader[columnName] == DBNull.Value || dataReader[columnName].ToString() == "{}")
            {
                if (columnName.ToUpper().Contains("GUID") || dataReader[columnName].ToString() == "{}")
                {
                    return Guid.Empty.ToString();
                }
                else
                {
                    return string.Empty;
                }
                    
            }
            else
            {
                
                return dataReader[columnName].ToString();
            }
             
        }

        private static DateTime IsDBNull(SqlDataReader dataReader, string columnName, string isdate)
        {
            if (dataReader[columnName] == DBNull.Value)
            {
                return DateTime.MinValue; 
            }
            else
            {
                return Convert.ToDateTime(dataReader[columnName]);
            }
        }

            public void Remove(evitiEligiblePatients entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<evitiEligiblePatients> entities)
        {
            throw new NotImplementedException();
        }

        IEnumerable<evitiEligiblePatients> IGenericRepository<evitiEligiblePatients>.GetAll()
        {
            throw new NotImplementedException();
        }

        evitiEligiblePatients IGenericRepository<evitiEligiblePatients>.GetById(object id)
        {
            throw new NotImplementedException();
        }

     
    }
}
