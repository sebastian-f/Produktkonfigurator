using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductConfigurator.Services.Interface
{
    public interface IMailService
    {
        void SendMail(string toEmailAddress, string toName, string subject, string body);
    }
}
