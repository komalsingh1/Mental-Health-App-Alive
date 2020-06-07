using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Core
{
    public class UserRegistrationComponent : IUserRegistrationComponent
    {
        private readonly IUserRegistrationAdapter _userRegistrationAdapter;
        public UserRegistrationComponent(IUserRegistrationAdapter userRegistrationAdapter)
        {
            _userRegistrationAdapter = userRegistrationAdapter;
        }
        public async Task<string>CreateAccount(UserDetails user)
        {
            if (!await _userRegistrationAdapter.IsValidEmailID(user.EmailID))
                throw ClientSideExceptions.InvalidEmail();
            if (!await _userRegistrationAdapter.RegisterUserAccount(user.EmailID, user.Name, user.Password, user.Gender, user.Age,user.Country,user.PhoneNumber,user.Pincode,user.ConnectWithOthers))
                throw ClientSideExceptions.RegistrationFailure();
            user.UserID= await _userRegistrationAdapter.GetUserId(user.EmailID);
            await _userRegistrationAdapter.RegisterUserForReport(user.UserID);
            return user.UserID;
        }
        public async Task<bool> LoginUser(string UserID, string Password)
        {
            if (!await _userRegistrationAdapter.IsValidUser(UserID))
                throw ClientSideExceptions.InvalidUser();
            if (!await _userRegistrationAdapter.LoginUser(UserID, Password))
                throw ClientSideExceptions.InvalidPassword();
            return true;
        }
    }
}
