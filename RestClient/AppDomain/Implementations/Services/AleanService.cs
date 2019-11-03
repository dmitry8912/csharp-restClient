using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestClient.AppDomain.Implementations.Clients;
namespace RestClient.AppDomain.Implementations.Services
{
    public static class AleanService
    {
        public static string apiUrl;
        public static string login;
        public static string password;

        public static Contracts Contracts
        {
            get
            {
                return new Contracts(AleanService.apiUrl,
                        AleanService.login,
                        AleanService.password); ;
            }
        }

        public static IncomingInvoices IncomingInvoices
        {
            get
            {
                return new IncomingInvoices(AleanService.apiUrl,
                        AleanService.login,
                        AleanService.password);
            }
        }
    }
}
