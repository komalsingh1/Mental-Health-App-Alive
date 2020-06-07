using System;
using System.Collections.Generic;
using System.Text;

namespace Mental.Health
{
    public class UserDetails
    {
        public string EmailID { get; set; }
         public string UserID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public long PhoneNumber { get; set; }
        public string Country { get; set; }
        public long Pincode { get; set; }
        public string Password { get; set; }
        public bool ConnectWithOthers { get; set; }
    }
}
