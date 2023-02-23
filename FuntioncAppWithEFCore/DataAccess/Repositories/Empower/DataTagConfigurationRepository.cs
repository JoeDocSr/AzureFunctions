using Empower.DataAccess.ApplicationContext.Empower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empower.DataAccess.Entities.Empower;
using Empower.DataAccess.Repositories.Empower.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Empower.DataAccess.Repositories.Empower
{
    public class DataTagConfigurationRepository : GenericRepository<DataTag>, IDataTagConfigurationRepository
    {
        private EmpowerContext _context;
        public DataTagConfigurationRepository(EmpowerContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<DataTag> GetDataTagById(long id)
        {
            return (IEnumerable<DataTag>)_context.DataTags.Where(dt => dt.Id== id).Include(tq => tq.TreatmentQuestionToDataTagConnectors).ToList();
        }

        public IEnumerable<DataTag> GetAllDataTags()
        {
            return (IEnumerable<DataTag>)_context.DataTags.Where(dt => dt.IsActive == true).ToList();
        }
    }
}
