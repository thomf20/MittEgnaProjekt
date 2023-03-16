using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MittEgnaProjekt.Components
{
    internal interface IValidationService
    {
        bool IsValidated(string username, string password);
    }
}
