using System.ComponentModel.DataAnnotations;

namespace myhealthhub.api.Models.Entities
{
    public class TrialForm
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
        public string SiteName { get; set; }

        [Required]
        public DateTime DateTrial { get; set; }

        [Required]
        public string SiteId { get; set; }

        [Required]
        public string SubjectId { get; set; }

        [Required]
        public string BloodPressure { get; set; }

        [Required]
        public string BodyWeight { get; set; }

        [Required]
        public string EPGUsed { get; set; }

        [Required]
        public string EPGModelNumber { get; set; }

        [Required]
        public string EPGSerialNumber { get; set; }

        [Required]
        public int TotalNumberLeads { get; set; }

        [Required]
        public bool APImagesCollectionStatus { get; set; }

        [Required]
        public bool LateralImagesCollectionStatus { get; set; }

        [Required]
        public bool ImagesEncryptedMemoryDriveStatus { get; set; }

        public string? ManufacturerLead1Model { get; set; }

        public string? ManufacturerLead1Lot { get; set; }

        public string? ManufacturerLead1Serial { get; set; }

        public string? ManufacturerLead1Notes { get; set; }

        public string? SpinalLevelLead1 { get; set; }

        public string? ManufacturerLead2Model { get; set; }

        public string? ManufacturerLead2Lot { get; set; }

        public string? ManufacturerLead2Serial { get; set; }

        public string? ManufacturerLead2Notes { get; set; }

        public string? SpinalLevelLead2 { get; set; }

        [Required]
        public bool AnatomicalGuidanceLeadStatus { get; set; }

        public bool? ParesthesiaMappingStatus { get; set; }

        [Required]
        public bool XMLFileDonwloadAndProvidedStatus { get; set; }

        public string? ProgramNumber1 { get; set; }

        public string? WaveForm1 { get; set; }

        public string? SpinalLevelFirstAnode1Lead1 { get; set; }

        public string? SpinalLevelFirstAnode1Lead2 { get; set; }

        public string? SpinalLevelFirstCathode1Lead1 { get; set; }

        public string? SpinalLevelFirstCathode1Lead2 { get; set; }

        public string? ProgramNumber2 { get; set; }

        public string? WaveForm2 { get; set; }

        public string? SpinalLevelFirstAnode2Lead1 { get; set; }

        public string? SpinalLevelFirstAnode2Lead2 { get; set; }

        public string? SpinalLevelFirstCathode2Lead1 { get; set; }

        public string? SpinalLevelFirstCathode2Lead2 { get; set; }

        public string? ProgramNumber3 { get; set; }

        public string? WaveForm3 { get; set; }

        public string? SpinalLevelFirstAnode3Lead1 { get; set; }

        public string? SpinalLevelFirstAnode3Lead2 { get; set; }

        public string? SpinalLevelFirstCathode3Lead1 { get; set; }

        public string? SpinalLevelFirstCathode3Lead2 { get; set; }

        public string? ProgramNumber4 { get; set; }

        public string? WaveForm4 { get; set; }

        public string? SpinalLevelFirstAnode4Lead1 { get; set; }

        public string? SpinalLevelFirstAnode4Lead2 { get; set; }

        public string? SpinalLevelFirstCathode4Lead1 { get; set; }

        public string? SpinalLevelFirstCathode4Lead2 { get; set; }

        public string? ProgramNumber5 { get; set; }

        public string? WaveForm5 { get; set; }

        public string? SpinalLevelFirstAnode5Lead1 { get; set; }

        public string? SpinalLevelFirstAnode5Lead2 { get; set; }

        public string? SpinalLevelFirstCathode5Lead1 { get; set; }

        public string? SpinalLevelFirstCathode5Lead2 { get; set; }

        [Required]
        public string LocationProcedure { get; set; }
    }
}