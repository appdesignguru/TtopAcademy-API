using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TtopAcademy.API.ApplicationCore.Entities
{
    public class Otp
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OtpID { get; set; }

        public OtpType OtpType { get; set; }
        public OtpStatus OtpStatus { get; set; }
        public string Email { get; set; }
        public int Code { get; set; }
        public int NumberOfResend { get; set; }
        public DateTime LastSentDateTime { get; set; } 
    }

    public enum OtpType
    {
        Registration, ForgotPassword
    }

    public enum OtpStatus
    {
        Active, Confirmed
    }
}