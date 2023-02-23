using Empower.DataAccess.ApplicationContext.Empower.Configurations;
using Empower.DataAccess.Entities.Empower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Empower.DataAccess.Repositories.Empower.Interfaces
{
    public interface ITreatmentQuestionsRepository : IGenericRepository<TreatmentQuestion>
    {
        TreatmentQuestion AddNewTreatmentQuestion(TreatmentQuestion question);
        IEnumerable<TreatmentQuestion> GetTreatmentQuestionConfigurations();
        IEnumerable<TreatmentQuestion> GetTreatmentQuestionById(long Id);
      
    }
}
