using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestClient.AppDomain.Models;
namespace RestClient.AppDomain.Implementations
{
    public class ServiceEntityClient : RestClient<ServiceEntity>
    {
        public ServiceEntityClient(string apiUrl) : base(apiUrl)
        {
            
        }
    }
}
