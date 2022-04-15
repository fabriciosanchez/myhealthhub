using System.ComponentModel.DataAnnotations;

namespace myhealthhub.api.Models.Entities
{
    public class Physician
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public List<StudyPerPhysician>? StudiesPerPhysicians { get; set; }

        public List<TrialCompletionForm>? TrialCompletionForms { get; set; }

        public List<TrialForm>? TrialForms { get; set; }

        public List<BaselineForm>? BaselineForms { get; set; }
    }
}