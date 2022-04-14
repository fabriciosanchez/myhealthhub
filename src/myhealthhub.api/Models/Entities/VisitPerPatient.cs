using System.ComponentModel.DataAnnotations;

namespace myhealthhub.api.Models.Entities
{
    public class VisitPerPatient
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid PatientId { get; set; }

        public Patient? Patient { get; set; }

        [Required]
        public Guid VisitId { get; set; }

        public Visit? Visit { get; set; }
    }
}