using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;
using TtopAcademy.API.ApplicationCore.Services;
using TtopAcademy.API.Infrastructure.Managers.Real;
using TtopAcademy.API.Infrastructure.Repositories.Fakes;
using TtopAcademy.API.Infrastructure.Services.Fakes;

namespace TtopAcademy.UnitTests.Managers
{
    [TestClass]
    public class OtpManagerTest
    {
        private OtpManager otpManager;
        private List<Otp> testOtps;

        [TestInitialize]
        public void InitializeBeforeEachTest()
        {
            testOtps = GetTestOtps();
            IOtpRepository fakeOtpRepository = new FakeOtpRepository(testOtps);
            IEmailService fakeEmailService = new FakeEmailService();
            otpManager = new OtpManager(fakeOtpRepository, fakeEmailService);
        }

        
        [TestCleanup]
        public void CleanUpAfterEachTest() 
        {
            otpManager = null;
            testOtps = null;
        }

        [TestMethod] 
        public async Task GenerateCodeAync_ShouldReturnCode()
        {
            string email = "test@gmail.com";
            OtpType otpType = OtpType.Registration; 

            int result = await otpManager.GenerateCodeAsync(email, otpType);

            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public async Task SendOtpToEmailAsync()
        {
            int code = 123456;
            string email = "dev@gmail.com";

            var result = await otpManager.SendOtpToEmailAsync(code, email);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public async Task ConfirmCodeAsync()
        {
            int code = 123456;
            string email = "example@gmail.com";
            OtpType otpType = OtpType.Registration;

            var result = await otpManager.ConfirmCodeAsync(code, email, otpType);

            Assert.IsTrue(result);
        }

        private List<Otp> GetTestOtps()
        {
            return new List<Otp>
            {
                new Otp { 
                    Code = 123456, Email = "example@gmail.com",
                    OtpType = OtpType.Registration, OtpStatus = OtpStatus.Active,
                    LastSentDateTime = DateTime.Now, NumberOfResend = 0
                }
            };
        }
    }
}
