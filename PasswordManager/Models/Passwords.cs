

namespace PasswordManager.Models
{
    public class Passwords
    {
        public Passwords(string password)
        {
            Password = password;
        }

        public string Description { get; set; }
        public string Url { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string CategoryId { get; set; }
    }
}
