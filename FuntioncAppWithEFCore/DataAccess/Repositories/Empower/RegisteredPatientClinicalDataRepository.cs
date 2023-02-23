using Empower.DataAccess.Entities.Empower;
using Microsoft.EntityFrameworkCore;
using Empower.DataAccess.ApplicationContext.Empower;
using Empower.DataAccess.Repositories.Empower.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Empower.DataAccess.Repositories.Empower
{
    public class RegisteredPatientClinicalDataRepository :
        GenericRepository<RegisteredPatientClinicalDatum>, IRegisteredPatientClinicalDataRepository
    {
        private readonly EmpowerContext _context;
        public RegisteredPatientClinicalDataRepository(EmpowerContext context) : base(context)
        {
            _context = context;
        }


        public IEnumerable<RegisteredPatientClinicalDatum> GetAllPatientClinicalData()
        {
            return (IEnumerable<RegisteredPatientClinicalDatum>)_context.RegisteredPatientClinicalData.OrderBy(x => x.Id);
        }

       
    }
}
