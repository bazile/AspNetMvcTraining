using System.Threading.Tasks;

namespace IoC_Demo
{
    public interface ISmtpSender
    {
        Task SendEmail(string to, string subject, string body);
    }
}
