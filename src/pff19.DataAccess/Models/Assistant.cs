using System.ComponentModel.DataAnnotations;

namespace pff19.DataAccess.Models
{
    public class Assistant
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Vorname { get; set; }

        public string Pfadiname { get; set; }

        [Required]
        public string Email { get; set; }

        public string Wishes { get; set; }
    }
}
