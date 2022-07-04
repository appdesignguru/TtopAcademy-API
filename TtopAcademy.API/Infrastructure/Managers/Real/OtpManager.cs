using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.ApplicationCore.Services;

namespace TtopAcademy.API.Infrastructure.Managers.Real
{
    /// <summary> Class for managing one time passwords (OTPs). </summary>
    public class OtpManager : IOtpManager
    {
        private readonly IOtpRepository otpRepository;
        private readonly IEmailService emailService;

        /// <summary> Constructs a new Otp manager with given parameters. </summary>
        public OtpManager(IOtpRepository otpRepository, IEmailService emailService)
        {
            this.otpRepository = otpRepository;
            this.emailService = emailService; 
        }

        public async Task<int> GenerateCodeAsync(string email, OtpType otpType)
        {
            Otp otp = await otpRepository.GetActiveOtpAsync(email, otpType);

            int numberOfResend = otp == null ? 0 : otp.NumberOfResend + 1;

            if (otp != null && otp.NumberOfResend >= 5)
            {
                return 0;
            }

            int code = GenerateCode();

            Otp dbEntry = await otpRepository.SaveOtpAsync(new Otp
            {
                Code = code, Email = email, OtpType = otpType,
                NumberOfResend = numberOfResend,
                LastSentDateTime = DateTime.Now,
                OtpStatus = OtpStatus.Active
            });

            if (dbEntry == null)
            {
                code = 0; // Something bad happened while saving to repository
            }
                
            return code;
        }

        public async Task<bool> ConfirmCodeAsync(int code, string email, OtpType otpType)
        {
            Otp otp = await otpRepository.GetActiveOtpAsync(email, otpType, code);
            if (otp == null)
            {
                return false;
            }
            await otpRepository.DeleteAsync(otp.OtpID);
            return true;
        }

        public async Task<bool> SendOtpToEmailAsync(int code, string email)
        {
            string message = "OTP code: " + code;
            bool emailSentStatus = await emailService.SendEmailAsync(message, email);
            return emailSentStatus;
        }

        private int GenerateCode()
        {
            // TODO: Generate Random Six-Digit integer
            int randomSixDigitInteger = 657483;
            return randomSixDigitInteger;
        }
    }
}