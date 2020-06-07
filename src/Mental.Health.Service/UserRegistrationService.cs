using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Service
{
    public class UserRegistrationService : IUserRegistrationService
    {
        private readonly IUserRegistrationComponent _userRegistrationComponent; 
        public UserRegistrationService(IUserRegistrationComponent userRegistrationComponent)
        {
            _userRegistrationComponent = userRegistrationComponent;
        }
        public async Task<SignUpResponse> CreateUserAccount(SignUpRequest request)
        {
            Validations.EnsureValid(request, new SignupRequestValidator());
            var result = await _userRegistrationComponent.CreateAccount(request.ToUserDetails());
            return new SignUpResponse() { UserID = result };
        }

        public async Task<SignInResponse> LoginUser(SignInRequest request)
        {
            Validations.EnsureValid(request, new SignInRequestValidator());
            var result = await _userRegistrationComponent.LoginUser(request.UserID, request.Password);
            return new SignInResponse() { IsLoggedInSuccessfully = result };
        }


       
    }
}
