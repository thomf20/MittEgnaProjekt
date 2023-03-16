using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittEgnaProjekt.Components
{
    internal class AuthenticationService : IAuthenticationService
    {
        //Dictionary till användarnamn samt lösenord.
        private Dictionary<string, string> _accounts = new Dictionary<string, string>();
        public AuthenticationService()
        {
            // Skapa ett testkonto
            _accounts.Add("test@gmail.com", "password1");
        }
        public bool IsAuthenticated(string username, string password)
        {
            //Kollar om användarnamnet finns och lösen matchar.
            if (!_accounts.ContainsKey(username) || _accounts[username] != password)
            {
                return false;
            }
            return true;
        }
        public bool CreateAccount(string username, string password)
        {
            //Kollar om användarnamnet inte är upptaget.
            if (_accounts.ContainsKey(username))
            {
                return false;
            }
            // Lägger till account till dictionary
            _accounts.Add(username, password);
            return true;
        }
    }
}

