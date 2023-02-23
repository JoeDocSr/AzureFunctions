using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empower.DataAccess.Entities.Empower;


namespace Empower.DataAccess.Repositories.Empower.Interfaces
{
    public interface IEligiblePatientsRepository : IGenericRepository<EligiblePatient>
    {
        IEnumerable<EligiblePatient> GetAllEligiblePatients();
        IEnumerable<EligiblePatient> GetAllEligiblePatientsByIds(List<long> ids);

    }
}
