using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health
{
    public interface IUserRegistrationComponent
    {
        Task<string> CreateAccount(UserDetails userDetails);
        Task<bool> LoginUser(string UserID, string Password);
    }
}
