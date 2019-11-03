using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestClient.AppDomain.Exceptions
{
    public class RestClientException : Exception
    {
        public RestClientException()
        {

        }

        public RestClientException(string message) : base(message)
        {

        }
    }
}
