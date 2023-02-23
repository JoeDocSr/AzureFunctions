using Empower.DataAccess.Entities.Empower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Empower.DataAccess.Repositories.Empower.Interfaces
{
    public interface IDataTagConfigurationRepository : IGenericRepository<DataTag>
    {
        IEnumerable<DataTag> GetDataTagById(long id);
        IEnumerable<DataTag> GetAllDataTags();
    }

}
