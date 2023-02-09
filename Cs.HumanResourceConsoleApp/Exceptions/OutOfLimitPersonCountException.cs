using System;
using System.Collections.Generic;
using System.Text;

namespace Cs.HumanResourceConsoleApp.Exceptions
{
    internal class OutOfLimitPersonCountException : Exception
    {
        public override string Message => "Personal sayi 10 neferi kece bilmez";

    }
}
