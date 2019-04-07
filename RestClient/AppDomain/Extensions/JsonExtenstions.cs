using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestClient.AppDomain.Models;
using RestClient.AppDomain.Interfaces;
using RestClient.AppDomain.Implementations;
namespace RestClient.AppDomain.Extensions
{
    public static class JsonExtenstions
    {
        public static string ToJson(this IEntity entity)
        {
            return JsonConvert.SerializeObject(entity);
        }
    }
}
