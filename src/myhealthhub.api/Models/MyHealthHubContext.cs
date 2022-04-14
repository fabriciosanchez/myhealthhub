using Microsoft.EntityFrameworkCore;
using myhealthhub.api.Models.Entities;

namespace myhealthhub.api.Models
{
    public class MyHealthHubContext : DbContext
    {
        public DbSet<FormLabel> FormsLabels { get; set; }

        public DbSet<Visit> Visits { get; set; }

        public DbSet<FormLabelPerVisit> FormLabelsPerVisits { get; set; }

        public MyHealthHubContext(DbContextOptions<MyHealthHubContext> options) : base(options) {  }
    }
}