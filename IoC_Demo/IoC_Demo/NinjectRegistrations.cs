using Ninject.Modules;
using System.Configuration;

namespace IoC_Demo
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            string smtpSender = ConfigurationManager.AppSettings["smtpSender"];
            switch (smtpSender)
            {
                case "DebugSmtpSender": Bind<ISmtpSender>().To<DebugSmtpSender>(); break;
                case "SmtpSender": Bind<ISmtpSender>().To<SmtpSender>(); break;

                default: Bind<ISmtpSender>().To<DummySmtpSender>(); break;
            }
            //Bind<IPayService>().To<BrainTreePayService>();
        }
    }
}
