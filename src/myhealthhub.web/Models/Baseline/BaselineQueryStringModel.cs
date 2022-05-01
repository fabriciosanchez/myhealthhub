namespace myhealthhub.web.Models.Baseline
{
    public class BaselineQueryStringModel
    {
        public string PatientInternalId { get; set; }

        public Guid VisitId { get; set; }

        public Guid FormLabelId { get; set; }

        public string PhysicianEmail { get; set; }
    }
}