using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestClient.AppDomain.Interfaces;
namespace RestClient.AppDomain.Implementations.Responses
{
    public class Response : IResponse
    {
        private string result;
        public override string Result {
            get
            {
                return this.result;
            }
        }
        public Response(string result)
        {
            this.result = result;
        }
    }
}
