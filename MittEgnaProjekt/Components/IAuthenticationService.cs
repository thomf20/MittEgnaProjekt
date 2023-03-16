using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittEgnaProjekt.Components
{
    internal interface IAuthenticationService
    {
        bool IsAuthenticated(string username, string password);
        bool CreateAccount(string username, string password);
    }
}
