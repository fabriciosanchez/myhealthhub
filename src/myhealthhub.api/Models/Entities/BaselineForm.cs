using System.ComponentModel.DataAnnotations;

namespace myhealthhub.api.Models.Entities
{
    public class BaselineForm
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
        public DateTime DateTimeBaseline { get; set; }

        [Required]
        public string SiteName { get; set; }

        [Required]
        public string SiteId { get; set; }

        [Required]
        public string SubjectId { get; set; }

        [Required]
        public string Sex { get; set; }

        [Required]
        public int AgeConsent { get; set; }

        [Required]
        public string Ethinicity { get; set; }

        public string? RaceAmericanIndian { get; set; }

        public string? RaceAsian { get; set; }

        public string? RaceBlackAfrican { get; set; }

        public string? RaceNativeHawaian { get; set; }

        public string? RaceWhiteCaucasian { get; set; }

        public string? RaceOther { get; set; }

        public string? RaceDeclined { get; set; }

        [Required]
        public string Weight { get; set; }

        [Required]
        public string Height { get; set; }

        [Required]
        public string BloodPressure { get; set; }

        [Required]
        public string WorkSituation { get; set; }

        [Required]
        public string PainPreventToWork { get; set; }

        [Required]
        public int DaysMissedDuePain { get; set; }

        [Required]
        public string ImpactPainInLife { get; set; }

        [Required]
        public string ExerciseFrequence { get; set; }

        [Required]
        public string InsuranceSituation { get; set; }

        [Required]
        public string WorkCompensation { get; set; }

        [Required]
        public string ActiveLitigation { get; set; }

        [Required]
        public bool SmokerStatus { get; set; }

        public int? TimeChronicPainYears { get; set; }

        public int? TimeChronicPainMonths { get; set; }

        [Required]
        public string ChronicPainRecurrency { get; set; }

        public string? ChronicPainEpisodeLasting { get; set; }

        public string? ChronicPainEpisodeIntensity { get; set; }

        public string? ChronicPainEpisodeFrequency { get; set; }

        public string? ChronicPainEpisodeFrequencyComparisson { get; set; }

        [Required]
        public int LevelPainZeroToTen { get; set; }

        [Required]
        public string ChronicPainLocationFrontStatus { get; set; }

        public bool ChronicPainLocationFront1 { get; set; }

        public bool ChronicPainLocationFront2 { get; set; }

        public bool ChronicPainLocationFront3 { get; set; }

        public bool ChronicPainLocationFront4 { get; set; }

        public bool ChronicPainLocationFront5 { get; set; }

        public bool ChronicPainLocationFront6 { get; set; }

        public bool ChronicPainLocationFront7 { get; set; }

        public bool ChronicPainLocationFront8 { get; set; }

        public bool ChronicPainLocationFront9 { get; set; }

        public bool ChronicPainLocationFront10 { get; set; }

        public bool ChronicPainLocationFront11 { get; set; }

        public bool ChronicPainLocationFront12 { get; set; }

        public bool ChronicPainLocationFront13 { get; set; }

        public bool ChronicPainLocationFront14 { get; set; }

        public bool ChronicPainLocationFront15 { get; set; }

        public bool ChronicPainLocationFront16 { get; set; }

        public bool ChronicPainLocationFront17 { get; set; }

        public bool ChronicPainLocationFront18 { get; set; }

        public bool ChronicPainLocationFront19 { get; set; }

        public bool ChronicPainLocationFront20 { get; set; }

        public bool ChronicPainLocationFront21 { get; set; }

        public bool ChronicPainLocationFront22 { get; set; }

        public bool ChronicPainLocationFront23 { get; set; }

        public bool ChronicPainLocationFront24 { get; set; }

        [Required]
        public string ChronicPainLocationBackStatus { get; set; }

        public bool ChronicPainLocationFront25 { get; set; }

        public bool ChronicPainLocationFront26 { get; set; }

        public bool ChronicPainLocationFront27 { get; set; }

        public bool ChronicPainLocationFront28 { get; set; }

        public bool ChronicPainLocationFront29 { get; set; }

        public bool ChronicPainLocationFront30 { get; set; }

        public bool ChronicPainLocationFront31 { get; set; }

        public bool ChronicPainLocationFront32 { get; set; }

        public bool ChronicPainLocationFront33 { get; set; }

        public bool ChronicPainLocationFront34 { get; set; }

        public bool ChronicPainLocationFront35 { get; set; }

        public bool ChronicPainLocationFront36 { get; set; }

        public bool ChronicPainLocationFront37 { get; set; }

        public bool ChronicPainLocationFront38 { get; set; }

        public bool ChronicPainLocationFront39 { get; set; }

        public bool ChronicPainLocationFront40 { get; set; }

        public bool ChronicPainLocationFront41 { get; set; }

        public bool ChronicPainLocationFront42 { get; set; }

        public bool ChronicPainLocationFront43 { get; set; }

        public bool ChronicPainLocationFront44 { get; set; }

        [Required]
        public bool ChronicPostOperativePainStatus { get; set; }

        public string? PostOperativePainTypeSurgery1 { get; set; }

        public string? PostOperativePainTypeSurgery2 { get; set; }

        public string? PostOperativePainTypeSurgery3 { get; set; }

        public string? PostOperativePainTypeSurgery4 { get; set; }

        public string? PostOperativePainTypeSurgery5 { get; set; }

        public string? PostOperativePainTypeSurgeryYear1 { get; set; }

        public string? PostOperativePainTypeSurgeryYear2 { get; set; }

        public string? PostOperativePainTypeSurgeryYear3 { get; set; }

        public string? PostOperativePainTypeSurgeryYear4 { get; set; }

        public string? PostOperativePainTypeSurgeryYear5 { get; set; }

        [Required]
        public bool FalledBackSurgerySyndromeStatus { get; set; }

        public string? FalledBackSyndromeTypeSurgery1 { get; set; }

        public string? FalledBackSyndromeTypeSurgery2 { get; set; }

        public string? FalledBackSyndromeTypeSurgery3 { get; set; }

        public string? FalledBackSyndromeTypeSurgery4 { get; set; }

        public string? FalledBackSyndromeTypeSurgery5 { get; set; }

        public string? FalledBackSyndromeTypeSurgeryLevel1 { get; set; }

        public string? FalledBackSyndromeTypeSurgeryLevel2 { get; set; }

        public string? FalledBackSyndromeTypeSurgeryLevel3 { get; set; }

        public string? FalledBackSyndromeTypeSurgeryLevel4 { get; set; }

        public string? FalledBackSyndromeTypeSurgeryLevel5 { get; set; }

        public bool BackPainStatus { get; set; }

        public bool BackPainFBSSStatus { get; set; }

        public bool NeckUperLimbSchemiaStatus { get; set; }

        public bool CriticalLimbSchemiaStatus { get; set; }

        public bool VisceralPainStatus { get; set; }

        public bool AnginaStatus { get; set; }

        public bool PeripheralNeuropathyStatus { get; set; }

        public bool DiabeticStatus { get; set; }

        public bool ChemotherapyRelatedStatus { get; set; }

        public bool ReflexSympatheticDystrophyStatus { get; set; }

        public bool CausalgiaStatus { get; set; }

        public bool CausalgiaMuscle { get; set; }

        public bool PostAmputationStatus { get; set; }

        [Required]
        public bool SubjectPrimaryChronicPainIndication { get; set; }

        public bool TreatmentForPainStatus { get; set; }

        public string? TreatmentYesOccupationalTherapy { get; set; }

        public string? TreatmentYesAcunpunture { get; set; }

        public string? TreatmentYesPhysicalTherapy { get; set; }

        public string? TreatmentYesMassageTherapy { get; set; }

        public string? TreatmentYesChiropracticTherapy { get; set; }

        public string? TreatmentYesCogBehavioralTherapy { get; set; }

        public string? TreatmentYesPsychotherapy { get; set; }

        public string? TreatmentYesHypnotherapy { get; set; }

        [Required]
        public string InjectionsInterventionsStatus { get; set; }

        public string? IITransforraminal { get; set; }

        public string? IITranslaminar { get; set; }

        public string? IICaudal { get; set; }

        public string? IIFacetInjections { get; set; }

        public string? IISacroillacJoint { get; set; }

        public string? IIOtherJoint { get; set; }

        public string? IIRadiofrequency { get; set; }

        public string? IIIntradiscal { get; set; }

        public string? IIPreviousSCS { get; set; }

        public string? IIPreviousDRG { get; set; }

        public bool ImplantableDrug { get; set; }
    }
}