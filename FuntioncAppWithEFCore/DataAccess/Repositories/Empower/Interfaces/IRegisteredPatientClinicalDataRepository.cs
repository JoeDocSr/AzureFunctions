using Empower.DataAccess.Entities.Empower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Empower.DataAccess.Repositories.Empower.Interfaces
{
    public interface IRegisteredPatientClinicalDataRepository : IGenericRepository<RegisteredPatientClinicalDatum>
    {

        IEnumerable<RegisteredPatientClinicalDatum> GetAllPatientClinicalData();

    }
}
