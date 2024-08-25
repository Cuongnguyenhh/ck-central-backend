using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Abstract.Services
{
    public interface IEmailSendBaseService
    {
        Task<bool> SendEmailAsync(string toEmail, string subject, string message);
    }
}
