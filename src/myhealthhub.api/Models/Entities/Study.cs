using System.ComponentModel.DataAnnotations;

namespace myhealthhub.api.Models.Entities
{
    public class Study
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public List<StudyPerVisit>? StudiesPerVisits { get; set; }

        public List<StudyPerPhysician>? StudiesPerPhysicians { get; set; }
    }
}