using Empower.DataAccess.ApplicationContext.Eviti;
using Empower.DataAccess.Entities.Eviti;
using Empower.DataAccess.Repositories.Eviti.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Empower.DataAccess.Repositories.Eviti
{
    public class ContactPayerLOBRepository : GenericRepository<ContactPayerLineOfBusiness>, IContactPayerLOBRepository
    {
        private readonly EvitiContext _context;
        public ContactPayerLOBRepository(EvitiContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<ContactPayerLineOfBusiness> GetAllByPayerId(Guid payerGuid)
        {
            return DbSet.Include(x=>x.Payer).Where(x => x.PayerGuid == payerGuid).OrderBy(x => x.Name);
        }

        public IEnumerable<ContactPayerLineOfBusiness> GetAllByPayerId(Guid[] payerGuids)
        {
            return DbSet.Include(x => x.Payer).Where(x => payerGuids.Contains(x.PayerGuid) ).OrderBy(x=>x.Payer.Name).ThenBy(x => x.Name);
        }

       
    }
}
