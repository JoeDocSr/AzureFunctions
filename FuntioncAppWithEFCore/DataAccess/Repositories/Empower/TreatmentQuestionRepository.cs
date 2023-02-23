using Empower.DataAccess.Entities.Empower;
using Microsoft.EntityFrameworkCore;

using Empower.DataAccess.ApplicationContext.Empower;
using Empower.DataAccess.Repositories.Empower.Interfaces;
using Empower.DataAccess.ApplicationContext.Empower.Configurations;


using System.Collections.Generic;
using System.Linq;

namespace Empower.DataAccess.Repositories.Empower
{
    public class TreatmentQuestionRepository : GenericRepository<TreatmentQuestion>, ITreatmentQuestionsRepository

    {
        private readonly EmpowerContext _context;
        public TreatmentQuestionRepository(EmpowerContext context) : base(context)
        {
            _context = context;
        }

        public TreatmentQuestion AddNewTreatmentQuestion(TreatmentQuestion question)
        {
            _context.TreatmentQuestions.Add(question);
            _context.SaveChanges();

            return question;
        }

        public IEnumerable<TreatmentQuestion> GetTreatmentQuestionConfigurations()
        {
            return _context.TreatmentQuestions.OrderByDescending(d => d.Id).ToList();

        }

        public IEnumerable<TreatmentQuestion> GetTreatmentQuestionById(long Id)
        {
            return (IEnumerable<TreatmentQuestion>)_context.TreatmentQuestions.Where(tqc => tqc.Id == Id).Include(p => p.TreatmentQuestionToDataTagConnectors).ToList();

        }
    }
}