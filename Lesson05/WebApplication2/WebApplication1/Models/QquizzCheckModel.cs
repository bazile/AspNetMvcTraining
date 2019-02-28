namespace WebApplication1.Models
{
    public class QquizzCheckModel
    {
        public int Index { get; set; }
        public QnA[] Answers { get; set; }
    }

    public class QnA
    {
        public int Q { get; set; }
        public int A { get; set; }
    }
}
