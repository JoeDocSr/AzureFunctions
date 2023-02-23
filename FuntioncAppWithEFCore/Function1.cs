using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Empower.DataAccess.ApplicationContext.Empower;
using Empower.DataAccess.ApplicationContext.Eviti;
using Empower.DataAccess.Entities.Empower;
using Empower.DataAccess.Entities.Eviti;
using Empower.DataAccess.Repositories.UnitOfWork;
using Empower.DataAccess.UnitOfWork.Interfaces;
using EmpowerEligiblePatients;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FuntioncAppWithEFCore
{
    public class EligliblePatientsAF
    {
        private readonly EvitiContext _evitiContext;
        private readonly EmpowerContext _empowerContext;

        public static CultureInfo culture = CultureInfo.CreateSpecificCulture("en-US");
        public static DateTimeStyles styles = DateTimeStyles.None;
        public static DateTime dateResult;
        public static ILogger _logger;

        //private readonly ServerOptions _myServerOptions;

        private static IEmpowerUnitOfWork _empowerUnitOfWork;
        private static IEvitiUnitOfWork _evitiUnitOfWork;
        private static ProcessData pd = new ProcessData();
        public EligliblePatientsAF(EvitiContext evitiContex, EmpowerContext empowerContext)
        {
            this._evitiContext = evitiContex;
            this._empowerContext = empowerContext;
            //_myServerOptions= myServerOptions;
        }

        [FunctionName("EligliblePatientsAF")]
        public void Run([TimerTrigger("0 */5 * * * *")] TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            StartTheProcess(DateTime.Now.AddDays(-40), DateTime.Now, log);
        }

        private void StartTheProcess(DateTime fromDate, DateTime toDate, ILogger log)
        {

            _evitiUnitOfWork = new EvitiUnitOfWork(_evitiContext);

            List<evitiEligiblePatients> listOfPatients = _evitiUnitOfWork.EvitiEligblePatientRepository.GetEvitiEligiblePatients(fromDate, toDate).ToList();

            log.LogInformation("FOUND {0} PATIENTS.", listOfPatients.Count.ToString());

            if (listOfPatients.Count > 0)
            {
                _empowerUnitOfWork = new EmpowerUnitOfWork(_empowerContext);
                log.LogInformation("**** GETTING LIST OF DATA TAGS****");

                List<DataTag> listOfDataTagConfgs = _empowerUnitOfWork.DataTagConfiguration.GetAllDataTags().ToList();
                log.LogInformation("**** FOUND {0} ACTIVE DATA TAGS ****", listOfDataTagConfgs.Count.ToString());

                log.LogInformation("**** PROCESSING PATIENTS AGAINST DATA TAGS ****.");
                pd.ProcessPatients(listOfPatients, listOfDataTagConfgs, _empowerContext, log);
                log.LogInformation("**** FINISHED PROCESSING PATIENTS AGAINST DATA TAGS ****");
            }
            else
            {
                log.LogInformation("****NO PATIENTS FOUND TO PROCESS****");
            }

            log.LogInformation("****ENDING PROCESS****");
        }
    }
}
