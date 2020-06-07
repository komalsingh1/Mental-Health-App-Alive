using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health
{
    public interface IUserRegistrationAdapter
    {
        Task<bool> IsValidEmailID(string EmailID);
        Task<bool> IsValidUser(string userId);
        Task<bool> RegisterUserAccount(string EmailID, string Name, string Password, string Gender, int Age, string Country, long PhoneNumber, long Pincode, bool ConnectWithOthers);
        Task<string> GetUserId(string EmailID);
        Task<bool> LoginUser(string UserID, string Password);
        Task<bool> RegisterUserForReport(String userId);
    }
}
