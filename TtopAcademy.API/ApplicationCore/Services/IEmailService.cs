using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TtopAcademy.API.ApplicationCore.Services
{
    /// <summary> Email service interface </summary>
    public interface IEmailService
    {
        /// <summary> Returns true if email is successfuly sent for given parameters. </summary>
        Task<bool> SendEmailAsync(string message, string senderEmail);  
    }
}
