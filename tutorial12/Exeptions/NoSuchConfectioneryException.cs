using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial12.Exeptions
{
    public class NoSuchConfectioneryException : Exception
    {
        public NoSuchConfectioneryException(string message)
            :base(message)
        {

        }
    }
}