using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestClient.AppDomain.Interfaces;
using RestClient.AppDomain.Models;
using RestClient.AppDomain.Extensions;
namespace RestClient.AppDomain.Implementations.Clients
{
    public class IncomingInvoices : RestClient<IncomingInvoice>
    {
        public IncomingInvoices(string apiUrl, string login, string password) : base(apiUrl, login, password)
        {
        }
    }
}
