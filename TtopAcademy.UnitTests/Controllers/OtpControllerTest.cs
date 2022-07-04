using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Managers;
using TtopAcademy.API.Controllers;
using TtopAcademy.API.Infrastructure.Managers.Fakes;
using TutorField.API.Models;

namespace TtopAcademy.UnitTests.Controllers
{
    [TestClass] 
    public class OtpControllerTest
    {
        [TestMethod]
        public async Task Post_ShouldReturnOk()
        {
            IOtpManager fakeOtpManager = new FakeOtpManager();
            OtpController otpController = new OtpController(fakeOtpManager);

            OtpBindingModel model = new OtpBindingModel { 
                Email = "example@gmail.com", OtpType = OtpType.Registration
            };
            IHttpActionResult actionResult = await otpController.Post(model);

            Assert.IsInstanceOfType(actionResult, typeof(OkResult));
        }
    }
}
