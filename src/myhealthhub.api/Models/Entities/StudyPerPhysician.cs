using System.ComponentModel.DataAnnotations;

namespace myhealthhub.api.Models.Entities
{
    public class StudyPerPhysician
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid StudyId { get; set; }

        public Study? Study { get; set; }

        [Required]
        public Guid PhysicianId { get; set; }

        public Physician? Physician { get; set; }
    }
}