using System;
using System.Collections.Generic;
using System.Text;

namespace Mental.Health.Adapter
{
    public interface IUsersManager
    {
        List<User> GetAllUsers();
        User GetUserById(string userId);
        bool AddUser(User user);
        bool UpdateUser(User user);
        bool DeleteUserById(string userId);
        bool ValidateUser(string id, string password);
        User GetUserByEmailId(string emailId);
        string GetUserIdByEmailId(string emailId);
        bool IsValidUserId(string id);
        bool isExistingUser(string emailId);
        bool SaveAnalyzedValue(string userId, string analyzedValue);
    }
}
