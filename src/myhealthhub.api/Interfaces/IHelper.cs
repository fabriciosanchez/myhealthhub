namespace myhealthhub.api.Services
{
    public interface IHelper
    {
        public string GenerateGuidAsString();

        public string GenerateDateAsString();

        public string RemoveDiacritics(string text);
    }
}