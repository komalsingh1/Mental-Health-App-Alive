using System.Text;

namespace Mental.Health.Adapter
{
    public class User
    {        
        public string EmailID { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public long PhoneNumber { get; set; }
        public string Country { get; set; }
        public long Pincode { get; set; }
        public string Password { get; set; }
        public bool ConnectWithOthers { get; set; }
        public string AnalyzedValue { get; set; }
    }
}
