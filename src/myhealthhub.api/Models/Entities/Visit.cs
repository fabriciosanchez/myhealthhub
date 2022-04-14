using System.ComponentModel.DataAnnotations;

namespace myhealthhub.api.Models.Entities
{
    public class Visit
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Visit Date")]
        public DateTime DateTimeVisit { get; set; }

        public string? Description { get; set; }

        public List<FormLabelPerVisit>? FormsLabelsPerVisits { get; set; }
    }
}