using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;

namespace TtopAcademy.API.ApplicationCore.Repositories
{
    /// <summary> OtpRepository repository interface. </summary>
    public interface IOtpRepository
    {
        /// <summary> Returns the code for given parameters or null if it doesn't exist. </summary>
        Task<Otp> GetActiveOtpAsync(string email, OtpType otpType, int code = 0);

        /// <summary> Returns saved OTP or null if saving not successful. </summary>
        Task<Otp> SaveOtpAsync(Otp otp);

        /// <summary> Returns deleted OTP or null if the OTP
        ///     to be deleted does not exist. </summary> 
        Task<Otp> DeleteAsync(int otpID); 
    }
}
