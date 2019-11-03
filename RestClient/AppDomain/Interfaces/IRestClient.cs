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
        IEnumerable<T> Get(IFilter filter);
        T Get(int id);
        IResponse Post(IEntity entity);
        IResponse Put(int id, IEntity entity);
        IResponse Delete(int id);
    }
}
