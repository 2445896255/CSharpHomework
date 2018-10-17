using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Program1
{
    public class MyException : ApplicationException
    {
        public MyException(string message) : base(message) { }
    }
}
