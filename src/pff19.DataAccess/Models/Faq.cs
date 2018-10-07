namespace pff19.DataAccess.Models
{
    public class Faq
    {
        public int Id { get; set; }

        public string QuestionDe { get; set; }

        public string QuestionFr { get; set; }

        public string AnswerDe { get; set; }

        public string AnswerFr { get; set; }

        public FaqCategory Category { get; set; }

        public int Order { get; set; }
    }

    public enum FaqCategory
    {

    }
}