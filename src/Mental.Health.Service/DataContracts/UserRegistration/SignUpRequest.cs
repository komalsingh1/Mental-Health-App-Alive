using System.Runtime.CompilerServices;

namespace Mental.Health.Service
{
    public class SignUpRequest
    {
        public string EmailID { get; set; }
        //Not keeping the userID here as the userid will be generated for client based on the names available in db
       // public string UserID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public long PhoneNumber { get; set; }
        public string Country { get; set; } = "India";
        public long Pincode { get; set; }
        public string Password { get; set; }
        public bool ConnectWithOthers { get; set; }

        public UserDetails ToUserDetails()
        {
            return new UserDetails()
            {
                EmailID = this.EmailID,
                Name = this.Name,
                Age = this.Age,
                Gender = this.Gender,
                Country = this.Country,
                PhoneNumber = this.PhoneNumber,
                Pincode = this.Pincode,
                Password = this.Password,
                ConnectWithOthers = this.ConnectWithOthers
            };
        }
    }
}