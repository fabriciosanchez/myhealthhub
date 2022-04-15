using Microsoft.EntityFrameworkCore;
using myhealthhub.api.Models.Entities;

namespace myhealthhub.api.Models
{
    public class MyHealthHubContext : DbContext
    {
        public DbSet<FormLabel> FormsLabels { get; set; }

        public DbSet<Visit> Visits { get; set; }

        public DbSet<FormLabelPerVisit> FormLabelsPerVisits { get; set; }

        public DbSet<Study> Studies { get; set; }

        public DbSet<StudyPerVisit> StudiesPerVisits { get; set; }

        public DbSet<Physician> Physicians { get; set; }

        public DbSet<StudyPerPhysician> StudiesPerPhysicians { get; set; }

        public DbSet<Upload> Uploads { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<VisitPerPatient> VisitsPerPatients { get; set; }

        public DbSet<TrialCompletionForm> TrialCompletionForms { get; set; }

        public DbSet<TrialForm> TrialForms { get; set; }

        public DbSet<BaselineForm> BaselineForms { get; set; }

        public MyHealthHubContext(DbContextOptions<MyHealthHubContext> options) : base(options) {  }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FormsLabelsPerVisits many to many
            modelBuilder.Entity<FormLabelPerVisit>().HasKey(flpv => new { flpv.FormLabelId, flpv.VisitId });
            modelBuilder.Entity<FormLabelPerVisit>().HasOne(fl => fl.FormLabel).WithMany(flpv => flpv.FormsLabelsPerVisits).HasForeignKey(fl => fl.FormLabelId);  
            modelBuilder.Entity<FormLabelPerVisit>().HasOne(v => v.Visit).WithMany(flpv => flpv.FormsLabelsPerVisits).HasForeignKey(v => v.VisitId);

            //StudiesPerVisits many to many
            modelBuilder.Entity<StudyPerVisit>().HasKey(spv => new { spv.StudyId, spv.VisitId });
            modelBuilder.Entity<StudyPerVisit>().HasOne(s => s.Study).WithMany(spv => spv.StudiesPerVisits).HasForeignKey(s => s.StudyId);  
            modelBuilder.Entity<StudyPerVisit>().HasOne(v => v.Visit).WithMany(spv => spv.StudiesPerVisits).HasForeignKey(v => v.VisitId);

            //StudiesPerPhysicians many to many
            modelBuilder.Entity<StudyPerPhysician>().HasKey(spp => new { spp.StudyId, spp.PhysicianId });
            modelBuilder.Entity<StudyPerPhysician>().HasOne(s => s.Study).WithMany(spp => spp.StudiesPerPhysicians).HasForeignKey(s => s.StudyId);  
            modelBuilder.Entity<StudyPerPhysician>().HasOne(p => p.Physician).WithMany(spp => spp.StudiesPerPhysicians).HasForeignKey(p => p.PhysicianId);

            //VisitsPerPatients many to many
            modelBuilder.Entity<VisitPerPatient>().HasKey(vpp => new { vpp.PatientId, vpp.VisitId });
            modelBuilder.Entity<VisitPerPatient>().HasOne(p => p.Patient).WithMany(vpp => vpp.VisitsPerPatients).HasForeignKey(p => p.PatientId);  
            modelBuilder.Entity<VisitPerPatient>().HasOne(v => v.Visit).WithMany(vpp => vpp.VisitsPerPatients).HasForeignKey(v => v.VisitId);
        }
    }
}