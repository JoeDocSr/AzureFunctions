using Empower.DataAccess.ApplicationContext.Empower;
using Empower.DataAccess.Entities.Empower;
using Empower.DataAccess.Repositories.Empower.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Empower.DataAccess.Repositories.Empower
{
    public class EligiblePatientRepository :
        GenericRepository<EligiblePatient>, IEligiblePatientsRepository
    {
        private readonly EmpowerContext _context;
        public EligiblePatientRepository(EmpowerContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<EligiblePatient> GetAllEligiblePatients()
        {            
            return (IEnumerable<EligiblePatient>)_context.EligiblePatients.OrderBy(x => x.Id);
        }

        public IEnumerable<EligiblePatient> GetAllEligiblePatientsByIds(List<long> ids)
        {
            return (IEnumerable<EligiblePatient>)_context.EligiblePatients.Where(e => ids.Contains(e.Id));   
        }
       
       
    }
}
