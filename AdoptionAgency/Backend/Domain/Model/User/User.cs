using AdoptionAgency.Backend.Domain.Model.Common;

namespace AdoptionAgency.Backend.Domain.Model.User
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }
        public Status Status { get; set; }
        public User(string username, string password, Status status)
        {
            Username = username;
            Password = password;
            Status = status;
        }
    }
}
