using AdoptionAgency.Backend.Domain.Model.Person;
using System.Security.Authentication;

namespace AdoptionAgency.Backend.Services.AuthentificationService
{
    public class LoginService
    {
        public LoginService() { } 

        public Person GetByCredentials(string username, string password)
        {
            // TODO: think about renaming
            var personService = new PersonService();
            var users = personService.GetAll();
            var user = users.FirstOrDefault(p => p.User.Username == username);

            if (user == null)
                throw new AuthenticationException("Invalid email address.");

            if (user.User.Password != password)
                throw new AuthenticationException("Invalid password.");

            return user;
        }

    }
}
