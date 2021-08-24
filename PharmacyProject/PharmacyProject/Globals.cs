using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace PharmacyProject
{
   public static class Globals
    {
        public static User LoggedUser;
        public static int LogInAttempts = 0;
        public const int AttemptsAllowed = 3;
    }
}
;