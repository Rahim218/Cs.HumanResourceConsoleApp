using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.HumanResourceConsoleApp.Exceptions
{
    internal class NotFoundEmployeeException:Exception
    {
        public override string Message => "Axtardiginiz no - lu isci tapilmadi";
    }
}
