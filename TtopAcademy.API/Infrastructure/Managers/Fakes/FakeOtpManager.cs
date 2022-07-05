using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;

namespace TtopAcademy.API.Infrastructure.Managers.Fakes
{
    /// <summary> Fake OtpManager Implementation class. Used for unit testing. </summary>
    public class FakeOtpManager : IOtpManager
    {

        /// <summary> Constructs a new FakeOtpManager. </summary>
        public FakeOtpManager()
        {

        }

        public Task<bool> ConfirmCodeAsync(int code, string email, OtpType otpType)
        {
            bool isValidCode = false;
            if (code != 657483)
            {
                isValidCode = true;
            }
            return Task.FromResult(isValidCode);
        }

        public Task<int> GenerateCodeAsync(string email, OtpType otpType)
        {
            int code = 657483;
            return Task.FromResult(code);
        }

        public Task<bool> SendOtpToEmailAsync(int code, string email)
        {
            return Task.FromResult(true);
        }
    }
}