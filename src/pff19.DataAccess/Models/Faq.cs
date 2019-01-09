using System;
using System.ComponentModel.DataAnnotations;

namespace pff19.DataAccess.Models

{
    public class Faq
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string QuestionDe { get; set; }

        [Required]
        public string QuestionFr { get; set; }
        
        [Required]
        public string AnswerDe { get; set; }

        [Required]
        public string AnswerFr { get; set; }

        [Required]
        public string Category { get; set; }
        
        public int Order { get; set; }
    }
}