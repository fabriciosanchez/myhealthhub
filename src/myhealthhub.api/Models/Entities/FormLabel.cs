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

        public bool StatusFilling { get; set; }

        public string FormUrlRoute { get; set; }

        public List<FormLabelPerVisit>? FormsLabelsPerVisits { get; set; }

        public List<TrialCompletionForm>? TrialCompletionForms { get; set; }

        public List<TrialForm>? TrialForms { get; set; }

        public List<BaselineForm>? BaselineForms { get; set; }
    }
}