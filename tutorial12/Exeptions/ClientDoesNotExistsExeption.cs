using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tutorial12.Exeptions
{
    public class ClientDoesNotExistsExeption : Exception
    {
        public ClientDoesNotExistsExeption(string message)
            : base(message)
        {

        }
    }
}