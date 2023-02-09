using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.HumanResourceConsoleApp.Exceptions
{
    internal class HasAlreadyBeenEmployeeEcxeption:Exception
    {
        public override string Message => "Bu No-lu isci artiq movcuddur";
    }
}
