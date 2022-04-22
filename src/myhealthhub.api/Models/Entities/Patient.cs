using System.ComponentModel.DataAnnotations;

namespace myhealthhub.api.Models.Entities
{
    public class Patient
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string InternalId { get; set; }

        [Required]
        public string Email { get; set; }

        public List<VisitPerPatient>? VisitsPerPatients { get; set; }
    }
}