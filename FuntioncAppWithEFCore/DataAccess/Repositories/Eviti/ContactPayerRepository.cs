using Empower.DataAccess.ApplicationContext.Eviti;
using Empower.DataAccess.ApplicationContext.Eviti.Configurations;
using Empower.DataAccess.Entities.Eviti;
using Empower.DataAccess.Repositories.Eviti.Interfaces;

namespace Empower.DataAccess.Repositories.Eviti
{
    public class ContactPayerRepository : GenericRepository<ContactPayer>, IContactPayerRepository
    {
        private readonly EvitiContext _context;
        public ContactPayerRepository(EvitiContext context) : base(context)
        {
            _context = context;
        }

       
    }
}
