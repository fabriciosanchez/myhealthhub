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

        public List<StudyPerVisit>? StudiesPerVisits { get; set; }

        public List<Upload>? Uploads { get; set; }

        public List<VisitPerPatient>? VisitsPerPatients { get; set; }

        public List<TrialCompletionForm>? TrialCompletionForms { get; set; }

        public List<TrialForm>? TrialForms { get; set; }

        public List<BaselineForm>? BaselineForms { get; set; }
    }
}