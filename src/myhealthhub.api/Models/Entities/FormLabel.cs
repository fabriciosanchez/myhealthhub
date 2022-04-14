using System.ComponentModel.DataAnnotations;

namespace myhealthhub.api.Models.Entities
{
    public class FormLabel
    {
        [Required]
        [Display(Name = "Form Label Id")]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Description { get; set; }

        public List<FormLabelPerVisit>? FormsLabelsPerVisits { get; set; }
    }
}