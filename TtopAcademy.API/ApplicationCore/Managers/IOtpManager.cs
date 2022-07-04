using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;

namespace TtopAcademy.API.ApplicationCore.Managers
{
    /// <summary> Interface  for managing one time passwords (OTP). </summary>
    public interface IOtpManager
    {
        /// <summary> Returns one time password code for the given parameters. </summary>
        Task<int> GenerateCodeAsync(string email, OtpType otpType);
       
        /// <summary> Returns true after successfully sending the 
        ///     given code to the specified email address. </summary>
        Task<bool> SendOtpToEmailAsync(int code, string email);

        /// <summary> Checks whether this is the code sent to the email for the given OTP type. </summary>
        Task<bool> ConfirmCodeAsync(int code, string email, OtpType otpType);
    }
}
