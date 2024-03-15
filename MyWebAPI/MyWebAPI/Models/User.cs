namespace MyWebAPI.Models
{
    // User.cs
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
    }

}
