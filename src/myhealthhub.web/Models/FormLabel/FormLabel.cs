namespace myhealthhub.web.Models.FormLabel
{
    public class FormLabel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public bool StatusFilling { get; set; }

        public string FormUrlRoute { get; set; }
    }
}