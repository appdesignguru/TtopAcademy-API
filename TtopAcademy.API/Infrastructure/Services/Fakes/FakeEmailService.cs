using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Services;

namespace TtopAcademy.API.Infrastructure.Services.Fakes
{
    public class FakeEmailService : IEmailService
    {
        public async Task<bool> SendEmailAsync(string message, string senderEmail)
        {
            return await Task.FromResult(true);
        }
    }
}