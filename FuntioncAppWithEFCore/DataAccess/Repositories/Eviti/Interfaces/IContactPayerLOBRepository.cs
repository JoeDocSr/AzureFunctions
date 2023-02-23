using Empower.DataAccess.Entities.Empower;
using Empower.DataAccess.Entities.Eviti;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Empower.DataAccess.Repositories.Eviti.Interfaces
{
    public interface IContactPayerLOBRepository : IGenericRepository<ContactPayerLineOfBusiness>
    {
        IEnumerable<ContactPayerLineOfBusiness> GetAllByPayerId(Guid payerGuid);
        IEnumerable<ContactPayerLineOfBusiness> GetAllByPayerId(Guid[] payerGuid);
    }

}
