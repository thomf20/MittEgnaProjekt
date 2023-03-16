using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittEgnaProjekt.Components
{
    internal class AuthorizationService : IAuthorizationService
    {
        public bool IsAuthorized(string username, string password)
        {
            //Kollar om användaren är authorized
            return true;
        }
    }
}
