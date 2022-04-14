using System.ComponentModel.DataAnnotations;

namespace myhealthhub.api.Models.Entities
{
    public class StudyPerVisit
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid VisitId { get; set; }

        public Visit? Visit { get; set; }

        [Required]
        public Guid StudyId { get; set; }

        public Study? Study { get; set; }
    }
}