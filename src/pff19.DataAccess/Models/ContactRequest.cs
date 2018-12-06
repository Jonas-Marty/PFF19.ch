using System;
using System.ComponentModel.DataAnnotations;

namespace pff19.DataAccess.Models
{
    public class ContactRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Mail { get; set; }

        public DateTime? SubmitedAt { get; set; }
    }
}
