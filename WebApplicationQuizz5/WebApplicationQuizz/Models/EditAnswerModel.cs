namespace WebApplicationQuizz.Models
{
    public class EditAnswerModel
    {
        public int Id { get; set; }
        public int QuizzId { get; set; }
        public int QuestionId { get; set; }
        public string Text { get; set; }
        public string Comment { get; set; }
        public bool Correct { get; set; }
    }
}
