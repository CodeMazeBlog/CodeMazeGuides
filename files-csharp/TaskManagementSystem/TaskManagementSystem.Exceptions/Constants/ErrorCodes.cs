using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagementSystem.Exceptions.Constants
{
    public class ErrorCodes
    {
        public const int GenericError = 5000;

        public const int TaskNotFound = 1001;

        public const int UserNotFound = 1002;

        public const int InvalidUsernameOrPassword = 2001;

        public const int RegisterFailed = 2002;
    }
}
