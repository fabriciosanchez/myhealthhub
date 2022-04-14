using System.ComponentModel.DataAnnotations;

namespace myhealthhub.api.Models.Entities
{
    public class TrialCompletionForm
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public Guid FormLabelId { get; set; }

        public FormLabel? FormsLabels { get; set; }

        [Required]
        public Guid VisitId { get; set; }

        public Visit? Visit { get; set; }

        [Required]
        public Guid PhysicianId { get; set; }

        public Physician? Physician { get; set; }

        [Required]
        public DateTime DateTrialImplant { get; set; }

        [Required]
        public string SiteName { get; set; }

        [Required]
        public string SiteId { get; set; }

        [Required]
        public string SubjectId { get; set; }

        [Required]
        public bool PainLocationNatureStatus { get; set; }

        [Required]
        public bool StudyTreatmentFeedbackStatus { get; set; }

        [Required]
        public bool VideoMotorAssessmentStatus { get; set; }

        [Required]
        public string BloodPressure { get; set; }

        [Required]
        public string BodyWeight { get; set; }

        [Required]
        public bool APIImagesCollectionStatus { get; set; }

        [Required]
        public bool LateralImagesCollectionStatus { get; set; }

        [Required]
        public string SpinalLevelCoverageLead1 { get; set; }

        [Required]
        public string SpinalLevelCoverageLead2 { get; set; }

        [Required]
        public bool ImageAddedEncryptedDriveStatus { get; set; }

        [Required]
        public DateTime DateTimeRemovalNeuromodulation { get; set; }

        [Required]
        public bool AdjustmentsMadeTrialPeriodStatus { get; set; }
    }
}