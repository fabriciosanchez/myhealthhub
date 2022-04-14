using System.ComponentModel.DataAnnotations;

namespace myhealthhub.api.Models.Entities
{
    public class FormLabelPerVisit
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        [Display(Name = "Form Label")]
        public Guid FormLabelId { get; set; }

        public FormLabel? FormLabel { get; set; }

        [Required]
        [Display(Name = "Visit")]
        public Guid VisitId { get; set; }

        public Visit? Visit { get; set; }
    }
}