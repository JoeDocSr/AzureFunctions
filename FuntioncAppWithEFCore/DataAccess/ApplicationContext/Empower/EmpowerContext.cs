using Empower.DataAccess.Entities.Empower;
using Microsoft.EntityFrameworkCore;
namespace Empower.DataAccess.ApplicationContext.Empower;

public partial class EmpowerContext : DbContext
{
    public EmpowerContext()
    {
    }

    public EmpowerContext(DbContextOptions<EmpowerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DataTag> DataTags { get; set; }

    public virtual DbSet<EligiblePatient> EligiblePatients { get; set; }

    public virtual DbSet<EmpowerFile> EmpowerFiles { get; set; }

    public virtual DbSet<FileDatum> FileData { get; set; }

    public virtual DbSet<PatientClinicalDataDrug> PatientClinicalDataDrugs { get; set; }

    public virtual DbSet<RegisteredPatientClinicalDatum> RegisteredPatientClinicalData { get; set; }

    public virtual DbSet<TreatmentQuestion> TreatmentQuestions { get; set; }

    public virtual DbSet<TreatmentQuestionToDataTagConnector> TreatmentQuestionToDataTagConnectors { get; set; }

    public virtual DbSet<TreatmentQuestionToFileConnector> TreatmentQuestionToFileConnectors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//            optionsBuilder.UseSqlServer("Data Source=devdb-01;Initial Catalog=EmpowerDB;Integrated Security=True;Trust Server Certificate=True;Command Timeout=300");
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AI");

            modelBuilder.ApplyConfiguration(new Configurations.DataTagConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EligiblePatientConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EmpowerFileConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.FileDatumConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PatientClinicalDataDrugConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.RegisteredPatientClinicalDatumConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TreatmentQuestionConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TreatmentQuestionToDataTagConnectorConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.TreatmentQuestionToFileConnectorConfiguration());
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
