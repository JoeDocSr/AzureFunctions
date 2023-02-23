using Empower.DataAccess.Entities.Empower;
using Empower.DataAccess.ApplicationContext.Empower;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empower.DataAccess.Repositories.Empower.Interfaces;
using Empower.DataAccess.Repositories.Empower;
using Empower.DataAccess.UnitOfWork.Interfaces;

namespace Empower.DataAccess.Repositories.UnitOfWork
{
    public class EmpowerUnitOfWork : IEmpowerUnitOfWork
    {
        private readonly EmpowerContext _context;
        public EmpowerUnitOfWork(EmpowerContext context)
        {
            _context = context;

            TreatmentQuestionConfiguration = new TreatmentQuestionRepository(_context);
            TreatmentQuestionToDataTagConnector = new TreatmentQuestionToDataTagConnectorRepository(_context);
            DataTagConfiguration = new DataTagConfigurationRepository(_context);
            RegisteredPatientClinicalData = new RegisteredPatientClinicalDataRepository(_context);
            EligiblePatientsRepository = new EligiblePatientRepository(_context);
        }

        public ITreatmentQuestionsRepository TreatmentQuestionConfiguration { get; set; }
        public ITreatmentQuestionToDataTagConnector TreatmentQuestionToDataTagConnector { get; set; }
        public IDataTagConfigurationRepository DataTagConfiguration { get; set; }
        public IRegisteredPatientClinicalDataRepository RegisteredPatientClinicalData { get; set; }
        public IEligiblePatientsRepository EligiblePatientsRepository { get; set; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

