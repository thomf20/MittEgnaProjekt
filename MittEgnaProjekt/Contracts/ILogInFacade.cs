using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittEgnaProjekt.Contracts
{
    internal interface ILogInFacade
    {
        bool CanLogIn(string username, string password);
        bool CreateAccount(string username, string password);
    }
}
