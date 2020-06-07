using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Service
{
    public interface IUserRegistrationService
    {
        Task<SignUpResponse> CreateUserAccount(SignUpRequest request);
        Task<SignInResponse> LoginUser(SignInRequest request);

    }
}
