using Empower.DataAccess.Entities.Eviti;
using Microsoft.EntityFrameworkCore;
namespace Empower.DataAccess.ApplicationContext.Eviti;

public partial class EvitiContext : DbContext
{
    //public EvitiContext()
    //{
    //}

    public EvitiContext(DbContextOptions<EvitiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ContactPayer> ContactPayers { get; set; }

    public virtual DbSet<ContactPayerLineOfBusiness> ContactPayerLineOfBusinesses { get; set; }

    public virtual DbSet<evitiEligiblePatients> evitiEligiblePatients { get; set; }

    public virtual DbSet<CarePlanSummaryData> CarePlanSummaryData { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//            optionsBuilder.UseSqlServer("Data Source=DEVDB-01;Initial Catalog=evitiDev;Persist Security Info=True;User ID=kbApp;Password=tanstaafl;Trust Server Certificate=True;Command Timeout=300");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new Configurations.ContactPayerConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.ContactPayerLineOfBusinessConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.evitiEligiblePatientsConfiguration());
        modelBuilder.ApplyConfiguration(new Configurations.CarePlanSummaryDataConfiguration());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
