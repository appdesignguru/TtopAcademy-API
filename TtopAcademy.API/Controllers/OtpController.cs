using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.Models;

namespace TtopAcademy.API.Controllers
{
    /// <summary> Controller for one time passwords (OTPs). </summary>
    public class OtpController : ApiController
    {
        private readonly IOtpManager otpManager;

        /// <summary> Constructs a new OTP controller with given parameter. </summary>
        public OtpController(IOtpManager otpManager)
        {
            this.otpManager = otpManager;
        }

        /// <summary> Saves the given data model. 
        ///     Route is POST: api/OTP. </summary> 
        public async Task<IHttpActionResult> Post(OtpBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int otpCode = await otpManager.GenerateCodeAsync(model.Email, model.OtpType);
            if (otpCode == 0)
            {
                return NotFound(); // Couldn't save to db
            }
            bool emailSent = await otpManager.SendOtpToEmailAsync(otpCode, model.Email);
            if (!emailSent)
            {
                return NotFound();
            }
            return Ok();
        }       
    }
}
