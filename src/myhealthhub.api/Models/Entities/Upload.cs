using System.ComponentModel.DataAnnotations;

namespace myhealthhub.api.Models.Entities
{
    public class Upload
    {
        [Key]
        [Required]
        public Guid Id { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public Guid VisitId { get; set; }

        public Visit? Visit { get; set; }
    }
}