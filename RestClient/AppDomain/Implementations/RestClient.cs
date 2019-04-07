using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestClient.AppDomain.Models;
using RestClient.AppDomain.Interfaces;
using RestClient.AppDomain.Extensions;
namespace RestClient.AppDomain.Implementations
{
    public abstract class RestClient<T>: IRestClient<T> where T : class
    {
        private string apiUrl;
        public RestClient(string apiUrl)
        {
            this.apiUrl = apiUrl;
        }

        public IEnumerable<T> Get()
        {
            using (var client = new HttpClient())
            {
                var response = client.GetAsync(this.apiUrl).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<IEnumerable<T>>(response.Content.ReadAsStringAsync().Result);
                } else {
                    // TODO : Implement custom exception
                    throw new Exception("HTTP Response code was not success");
                }
            }
        }

        public T Post(IEntity entity)
        {
            using (var client = new HttpClient())
            {
                var response = client.PostAsync(this.apiUrl, new StringContent(entity.ToJson())).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    // TODO : Implement custom exception
                    throw new Exception("HTTP Response code was not success");
                }
            }
        }

        public T Put(int id, IEntity entity)
        {
            using (var client = new HttpClient())
            {
                var response = client.PutAsync(String.Format("{0}/{1}",this.apiUrl,id), new StringContent(entity.ToJson())).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    // TODO : Implement custom exception
                    throw new Exception("HTTP Response code was not success");
                }
            }
        }

        public T Delete(int id)
        {
            using (var client = new HttpClient())
            {
                var response = client.DeleteAsync(String.Format("{0}/{1}", this.apiUrl, id)).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    // TODO : Implement custom exception
                    throw new Exception("HTTP Response code was not success");
                }
            }
        }


    }
}
