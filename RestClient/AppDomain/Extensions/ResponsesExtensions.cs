using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestClient.AppDomain.Models;
using RestClient.AppDomain.Implementations.Responses;
using RestClient.AppDomain.Interfaces;
using Newtonsoft.Json;
namespace RestClient.AppDomain.Extensions
{
    public static class ResponsesExtensions
    {
        public static Payment ToPayment(this IResponse response)
        {
            return response.Result == null ? null : JsonConvert.DeserializeObject<Payment>(response.Result);
        }
    }
}
