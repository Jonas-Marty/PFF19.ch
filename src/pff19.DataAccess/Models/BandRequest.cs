using System.ComponentModel.DataAnnotations;

namespace pff19.DataAccess.Models
{
    public class BandRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        public string ReferenceToScout { get; set; }
    }
}
