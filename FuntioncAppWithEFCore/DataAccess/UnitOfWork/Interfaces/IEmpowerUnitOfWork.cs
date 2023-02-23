using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Empower.DataAccess.Repositories.Empower.Interfaces;

namespace Empower.DataAccess.UnitOfWork.Interfaces
{
    public interface IEmpowerUnitOfWork : IDisposable
    {
        ITreatmentQuestionsRepository TreatmentQuestionConfiguration { get; }
        ITreatmentQuestionToDataTagConnector TreatmentQuestionToDataTagConnector { get; }
        IDataTagConfigurationRepository DataTagConfiguration { get; }
        IRegisteredPatientClinicalDataRepository RegisteredPatientClinicalData { get; }        
        IEligiblePatientsRepository EligiblePatientsRepository { get; set; }
        int Complete();
    }
}
