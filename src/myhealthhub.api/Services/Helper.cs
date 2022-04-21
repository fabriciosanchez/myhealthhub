using System.Globalization;
using System.Text;

namespace myhealthhub.api.Services
{
    public class Helper : IHelper
    {
        public string GenerateGuidAsString()
        {
            return Convert.ToString(Guid.NewGuid());
        }

        public string GenerateDateAsString()
        {
            string day = DateTime.Now.Day.ToString();
            string month = DateTime.Now.Month.ToString();
            string year = DateTime.Now.Year.ToString();
            return $"{month}-{day}-{year}";
        }

        public string RemoveDiacritics(string text) 
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder(capacity: normalizedString.Length);

            for (int i = 0; i < normalizedString.Length; i++)
            {
                char c = normalizedString[i];
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder
                .ToString()
                .Normalize(NormalizationForm.FormC);
        }
    }
}