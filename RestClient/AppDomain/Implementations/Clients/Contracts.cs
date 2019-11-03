using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestClient.AppDomain.Interfaces;
using RestClient.AppDomain.Models;
namespace RestClient.AppDomain.Implementations.Clients
{
    public class Contracts : RestClient<ContractEntity>
    {
        public Contracts(string apiUrl, string login, string password) : base(apiUrl, login, password)
        {

        }
    }
}
