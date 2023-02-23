using Empower.DataAccess.ApplicationContext.Empower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empower.DataAccess.Entities.Empower;
using Empower.DataAccess.Repositories.Empower.Interfaces;

namespace Empower.DataAccess.Repositories.Empower
{
    public class TreatmentQuestionToDataTagConnectorRepository : GenericRepository<TreatmentQuestionToDataTagConnector>, ITreatmentQuestionToDataTagConnector
    {
        public TreatmentQuestionToDataTagConnectorRepository(EmpowerContext context) : base(context)
        {
        }

    }
}
