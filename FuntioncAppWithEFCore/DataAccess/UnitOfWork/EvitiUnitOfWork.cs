using Empower.DataAccess.ApplicationContext.Eviti;
using Empower.DataAccess.Repositories.Eviti;
using Empower.DataAccess.Repositories.Eviti.Interfaces;
using Empower.DataAccess.UnitOfWork.Interfaces;

namespace Empower.DataAccess.Repositories.UnitOfWork
{
    public class EvitiUnitOfWork : IEvitiUnitOfWork
    {
        private readonly EvitiContext _context;
        public EvitiUnitOfWork(EvitiContext context)
        {
            _context = context;

            ContactPayerRepository = new ContactPayerRepository(_context);
            ContactPayerLOBRepository = new ContactPayerLOBRepository(_context);
            EvitiEligblePatientRepository = new evitiEligblePatientRepository(_context);
            CarePlanSummaryDataRepository = new CarePlanSummaryDataRepository(_context);
        }

        public IContactPayerRepository  ContactPayerRepository { get; set; }
        public IContactPayerLOBRepository ContactPayerLOBRepository { get; set; }

        public IEvitiEligblePatientRepository EvitiEligblePatientRepository { get; set; }   

        public ICarePlanSummaryDataRepository CarePlanSummaryDataRepository { get; set; }
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

