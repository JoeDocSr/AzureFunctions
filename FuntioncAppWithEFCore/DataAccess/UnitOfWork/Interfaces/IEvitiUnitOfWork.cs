using Empower.DataAccess.Repositories.Empower.Interfaces;
using Empower.DataAccess.Repositories.Eviti.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Empower.DataAccess.UnitOfWork.Interfaces
{
    public interface IEvitiUnitOfWork : IDisposable
    {
        IContactPayerRepository ContactPayerRepository { get; }
        IContactPayerLOBRepository ContactPayerLOBRepository { get; }
        IEvitiEligblePatientRepository EvitiEligblePatientRepository { get; }
        ICarePlanSummaryDataRepository CarePlanSummaryDataRepository { get;  }
        int Complete();
    }
}
