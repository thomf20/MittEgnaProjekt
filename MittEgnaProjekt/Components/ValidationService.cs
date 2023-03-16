using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MittEgnaProjekt.Components
{
    internal class ValidationService : IValidationService
    {
        public bool IsValidated(string username, string password)
        {
            // Regex för att se om användarnamnet är en mejladress
            Regex regex = new Regex(@"^[^@\s]+@[^@\s]+\.[^@\s]+$");
            if (!regex.IsMatch(username) || username == null)
            {
                return false;
            }

            // Kollar om lösenordet innehåller minst 6 bokstäver/siffror.
            if (password.Length < 6 || !password.Any(char.IsDigit))
            {
                return false;
            }

            return true;
        }
    }
}
