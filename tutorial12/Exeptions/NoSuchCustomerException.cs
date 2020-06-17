using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial12.Exeptions
{
    public class NoSuchCustomerException : Exception
    {
        public NoSuchCustomerException(string message)
            :base(message)
        {

        }
    }
}
