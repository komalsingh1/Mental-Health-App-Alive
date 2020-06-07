using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mental.Health.Adapter
{
    public class UsersManager : IUsersManager
    {
        private static List<User> _users;
        private static Dictionary<string, int> NameCountMap = new Dictionary<string, int>();
        private Regex emailPattern = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        public UsersManager()
        {
            try
            {
                _users = JsonFileHandler.ReadFile<User>(KeyStore.FilePaths.Users) ?? new List<User>();
                foreach(var user in _users)
                {
                    NameCountMap.TryAdd(user.UserName.Split(" ")[0].ToUpper(), 1);
                }
            }
            catch
            {
                _users = new List<User>();
            }
        }
        public bool AddUser(User user)
        {
            if (string.IsNullOrEmpty(user?.EmailID))
                return false;
            if (isExistingUser(user.EmailID))
                return false;
            user.UserId = GenerateUserId(user.UserName);            
            lock(_users)
                _users.Add(user);
            return JsonFileHandler.WriteInFile(_users, KeyStore.FilePaths.Users);
        }

        public bool isExistingUser(string emailId)
        {
            if (!string.IsNullOrEmpty(GetUserIdByEmailId(emailId)))
                return true;
            return false;
        }

        public bool DeleteUserById(string userId)
        {
            if (string.IsNullOrEmpty(userId))
                return false;
            lock (_users)
            {
                var user = GetUserById(userId);
                if (user == null)
                    return true;
                _users.Remove(user);
            }
            return JsonFileHandler.WriteInFile(_users, KeyStore.FilePaths.Users);
        }

        public List<User> GetAllUsers()
        {
            return _users;
        }
        
        public bool ValidateUser(string id,string password)
        {
            if (emailPattern.Match(id).Success)
                return ValidateUserByEmail(id, password);
            else
                return ValidateUserByUserId(id, password);
        }

       
        public bool IsValidUserId(string id)
        {
            return _users.Exists(user => user.EmailID.Equals(id) || user.UserId.Equals(id));
        }
        public string GetUserIdByEmailId(string emailId)
        {
          var result= string.IsNullOrEmpty(emailId) ? null : _users.Where(user => string.Equals(emailId, user.EmailID)).FirstOrDefault();
            return result?.UserId;
        }

        
        public bool UpdateUser(User user)
        {
            if (string.IsNullOrEmpty(user?.UserId))
                return false;
            lock (_users)
            {
                var existingUser = GetUserById(user.UserId);
                if (existingUser != null)
                    return AddUser(user);
                existingUser.UserName = user.UserName;
                existingUser.Gender = user.Gender;
                existingUser.Age = user.Age;
                existingUser.EmailID = user.EmailID;
                existingUser.PhoneNumber = user.PhoneNumber;
                existingUser.Country = user.Country;
                existingUser.Pincode = user.Pincode;
                existingUser.Password = user.Password;
                existingUser.ConnectWithOthers = user.ConnectWithOthers;
                existingUser.AnalyzedValue = user.AnalyzedValue;
                return JsonFileHandler.WriteInFile(_users, KeyStore.FilePaths.Users);
            }
        }

        private string GenerateUserId(string Name)
        {
            var firstName = Name.Split(" ")[0].ToUpper();
            if (!NameCountMap.ContainsKey(firstName))
            {
                NameCountMap.Add(firstName, 1);
                return firstName;
            }
            else
            {
                int currentCount = NameCountMap[firstName];
                NameCountMap[firstName] = currentCount + 1;
                return firstName + currentCount;
            }


        }
        private bool ValidateUserByUserId(string userId, string password)
        {
            return _users.Exists(user => string.Equals(userId, user.UserId) && string.Equals(password, user.Password));
           
        }

        private bool ValidateUserByEmail(string emailId, string password)
        {
            return _users.Exists(user => string.Equals(emailId, user.EmailID) && string.Equals(password, user.Password));
            
        }

        public User GetUserById(string userId)
        {
            return string.IsNullOrEmpty(userId) ? null : _users.Where(user => string.Equals(userId, user.UserId)).FirstOrDefault();
        }

        public User GetUserByEmailId(string emailId)
        {
            return string.IsNullOrEmpty(emailId) ? null : _users.Where(user => string.Equals(emailId, user.EmailID)).FirstOrDefault();
        }

        public bool SaveAnalyzedValue(string userId, string analyzedValue)
        {
            var user = GetUserById(userId);
            user.AnalyzedValue = analyzedValue;
            return JsonFileHandler.WriteInFile(_users, KeyStore.FilePaths.Users);
        }
    }
}
