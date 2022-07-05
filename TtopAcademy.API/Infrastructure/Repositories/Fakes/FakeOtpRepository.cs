using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TtopAcademy.API.ApplicationCore.Entities;
using TtopAcademy.API.ApplicationCore.Repositories;

namespace TtopAcademy.API.Infrastructure.Repositories.Fakes
{
    /// <summary> Fake otp repository implemetation class. Used for unit testing. </summary>
    public class FakeOtpRepository : IOtpRepository
    {
        private readonly List<Otp> otpList;

        /// <summary> Constructs a new FakeOtpRepository with given parameter. </summary>
        public FakeOtpRepository(List<Otp> otpList)
        {
            this.otpList = otpList;
        }

        public async Task<Otp> DeleteAsync(int otpID)
        {
            Otp otp = otpList.FirstOrDefault(p => p.OtpID == otpID);
            if (otp != null)
            {
                otpList.Remove(otp);
            }
            return await Task.FromResult(otp);
        } 

        public async Task<Otp> GetActiveOtpAsync(string email, OtpType otpType, int code = 0)
        {
            Otp otp = otpList.FirstOrDefault(p => p.Email == email 
                                            && p.Code == code && p.OtpType == otpType
                                            && p.OtpStatus == OtpStatus.Active);
            return await Task.FromResult(otp);
        }

        public async Task<Otp> SaveOtpAsync(Otp otp)
        {
            otpList.Add(otp);
            return await Task.FromResult(otp);
        }

        public Task<Otp> UpdateOtpAsync(Otp otp)
        {
            throw new NotImplementedException();
        }
    }
}