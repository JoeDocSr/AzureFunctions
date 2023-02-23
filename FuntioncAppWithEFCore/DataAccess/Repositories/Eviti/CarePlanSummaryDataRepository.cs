using Empower.DataAccess.ApplicationContext.Eviti;
using Empower.DataAccess.Entities.Eviti;
using Empower.DataAccess.Repositories.Eviti.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace Empower.DataAccess.Repositories.Eviti
{
    public class CarePlanSummaryDataRepository : GenericRepository<CarePlanSummaryDataRepository>, ICarePlanSummaryDataRepository
    {
        private readonly EvitiContext _context;
        public CarePlanSummaryDataRepository(EvitiContext context) : base(context)
        {
            _context = context;
        }

        public void Add(CarePlanSummaryData entity)
        {
            throw new NotImplementedException();
        }

        public void AddRange(IEnumerable<CarePlanSummaryData> entities)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CarePlanSummaryData> Find(Expression<Func<CarePlanSummaryData, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public CarePlanSummaryData GetCarePlanDataByCarePlanGuid(Guid cpGuid)
        {
            
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = (Microsoft.Data.SqlClient.SqlConnection)_context.Database.GetDbConnection();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetCarePlanSummaryDataForEmpower";

            SqlParameter paramCarePlanGuid = new SqlParameter("@CarePlanGuid", System.Data.SqlDbType.UniqueIdentifier);
            paramCarePlanGuid.SqlValue = cpGuid;           

            cmd.Parameters.Add(paramCarePlanGuid);
            cmd.Connection.Open();

            SqlDataReader dataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);          

            CarePlanSummaryData returnCPSD = GetDataFromReader(dataReader);
            cmd.Connection.Close();

            return returnCPSD;


        }

        private CarePlanSummaryData GetDataFromReader(SqlDataReader dr)
        {
            CarePlanSummaryData cpData = new CarePlanSummaryData();

            while (dr.Read())
            {
                evitiEligiblePatients eep = new evitiEligiblePatients();

                cpData.PayerName = Utility.IsDBNull(dr, "PayerName");
                cpData.PayerLobName = Utility.IsDBNull(dr, "PayerLobName");
                cpData.PatientFullName = Utility.IsDBNull(dr, "PatientFullName");
                cpData.Gender = Utility.IsDBNull(dr, "Gender");
                cpData.CancerTypeGUID = new Guid(Utility.IsDBNull(dr, "CancerTypeGUID"));
                cpData.CancerType = Utility.IsDBNull(dr, "CancerType");
                cpData.Pathology = Utility.IsDBNull(dr, "Pathology");
                cpData.CancerPathologyGUID = new Guid(Utility.IsDBNull(dr, "CancerPathologyGUID"));
                cpData.CancerStageGUID = new Guid(Utility.IsDBNull(dr, "CancerStageGUID"));
                cpData.Stage = Utility.IsDBNull(dr, "Stage");
                cpData.PrimaryStandardCode = Utility.IsDBNull(dr, "PrimaryStandardCode");
                cpData.CarePlanName = Utility.IsDBNull(dr, "CarePlanName");
                cpData.StartDate = Utility.IsDBNull(dr, "StartDate", "d");
                cpData.EndDate = Utility.IsDBNull(dr, "EndDate", "d");
                cpData.LineOfTreatment = Utility.IsDBNull(dr, "LineOfTreatment");
                cpData.TreatmentGoal = Utility.IsDBNull(dr, "TreatmentGoal");
                cpData.CarePlanDrugNames = Utility.IsDBNull(dr, "CarePlanDrugNames");
                cpData.CancerStageGUID = new Guid(Utility.IsDBNull(dr, "CancerStageGUID"));
                cpData.BioMarkerAndValuesGuids = Utility.IsDBNull(dr, "BioMarkerAndValuesGuids");
                cpData.SubscriberInsuredID = Utility.IsDBNull(dr, "SubscriberInsuredID");
                cpData.PatientHeight = Utility.IsDBNull(dr, "PatientHeight");
                cpData.PatientWeight = Utility.IsDBNull(dr, "PatientWeight");
                //cpData.BodySurfaceArea = (int)dr["BodySurfaceArea"];
                cpData.ICDCode = Utility.IsDBNull(dr, "ICDCode");


            }
            dr.Close();
            return cpData;
        }

        public void Remove(CarePlanSummaryData entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<CarePlanSummaryData> entities)
        {
            throw new NotImplementedException();
        }

        IEnumerable<CarePlanSummaryData> IGenericRepository<CarePlanSummaryData>.GetAll()
        {
            throw new NotImplementedException();
        }

        CarePlanSummaryData IGenericRepository<CarePlanSummaryData>.GetById(object id)
        {
            throw new NotImplementedException();
        }

        
    }
}
