using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestClient.AppDomain.Models;
namespace RestClient.AppDomain.Interfaces
{
    interface IRestClient<T> where T : class
    {
        IEnumerable<T> Get();
        T Post(IEntity entity);
        T Put(int id, IEntity entity);
        T Delete(int id);
    }
}
