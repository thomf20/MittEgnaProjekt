using MittEgnaProjekt.Components;
using MittEgnaProjekt.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittEgnaProjekt.ApplicationFacade
{
    internal class LogInFacade : ILogInFacade
    {
        private readonly IValidationService _validationService;
        private readonly IAuthenticationService _authenticationService;
        private readonly IAuthorizationService _authorizationService;

        public LogInFacade()
        {
            _validationService = new ValidationService();
            _authenticationService = new AuthenticationService();
            _authorizationService = new AuthorizationService();
        }
        public bool CanLogIn(string username, string password)
        {
            //Ser om kontot är validated, authenticated samt authorized
            if (_validationService.IsValidated(username, password)
                && _authenticationService.IsAuthenticated(username, password)
                && _authorizationService.IsAuthorized(username, password))
            {
                return true;
            }
            return false;
        }
        public bool CreateAccount(string username, string password)
        {
            // Validate och skapa konto.
            if (_validationService.IsValidated(username, password)
                && _authenticationService.CreateAccount(username, password))
            {
                return true;
            }
            return false;
        }
    }
}
