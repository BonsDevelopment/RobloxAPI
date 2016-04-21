using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobloxAPI.Exceptions
{
    public class UnableToLocateException : Exception
    {
        public UnableToLocateException(string ex) : base(ex) { }
    }
}
