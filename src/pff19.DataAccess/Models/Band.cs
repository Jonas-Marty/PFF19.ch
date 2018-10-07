using System.ComponentModel.DataAnnotations;

namespace pff19.DataAccess.Models
{
    public class Band
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string DescriptionDe { get; set; }
        [Required]
        public string DescriptionFr { get; set; }
    }
}
