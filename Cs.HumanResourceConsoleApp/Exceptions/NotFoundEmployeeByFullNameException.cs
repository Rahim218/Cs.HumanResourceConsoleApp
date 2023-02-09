using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.HumanResourceConsoleApp.Exceptions
{
    internal class NotFoundEmployeeByFullNameException:Exception
    {
        public override string Message => "Bu adda isci yoxdur";
    }
}
