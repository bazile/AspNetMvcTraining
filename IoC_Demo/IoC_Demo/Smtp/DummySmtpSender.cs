using System.Threading.Tasks;

namespace IoC_Demo
{
    public class DummySmtpSender : ISmtpSender
    {
        public Task SendEmail(string to, string subject, string body)
        {
            // Делаем вид что почта отправлена успешно
            return Task.CompletedTask;
        }
    }
}