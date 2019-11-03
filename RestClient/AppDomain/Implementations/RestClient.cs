using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestClient.AppDomain.Models;
using RestClient.AppDomain.Interfaces;
using RestClient.AppDomain.Extensions;
using RestClient.AppDomain.Exceptions;
using RestClient.AppDomain.Implementations.Responses;
namespace RestClient.AppDomain.Implementations
{
    public abstract class RestClient<T>: IRestClient<T> where T : class
    {
        private string apiUrl;
        private string login;
        private string password;
        public virtual string url
        {
            get
            {
                return String.Format("{0}{1}/", apiUrl, this.GetType().Name);
            }
        }
        public RestClient(string apiUrl, string login, string password)
        {
            this.apiUrl = apiUrl.Last() != '/' ? apiUrl+'/' : apiUrl;
            this.login = login;
            this.password = password;
        }

        public virtual IEnumerable<T> Get(IFilter filter)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                    System.Text.ASCIIEncoding.ASCII.GetBytes(
               $"{login}:{password}")));
                var response = client.GetAsync(this.url+(filter == null ? "" : filter.BuildQueryString())).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<IEnumerable<T>>(response.Content.ReadAsStringAsync().Result);
                } else {
                    if(response.Content.ReadAsStringAsync().Result != String.Empty && response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var error = JsonConvert.DeserializeObject<Error>(response.Content.ReadAsStringAsync().Result);
                        throw new RestClientException(error.error);
                    }
                    else if (response.Content.ReadAsStringAsync().Result != String.Empty && response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new RestClientException("Ошибка авторизации веб-сервиса");
                    }
                    else
                    {
                        throw new RestClientException("При выполнении запроса произошла ошибка");
                    }
                }
            }
        }

        public virtual T Get(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                    System.Text.ASCIIEncoding.ASCII.GetBytes(
               $"{login}:{password}")));
                var response = client.GetAsync(this.url + id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    return JsonConvert.DeserializeObject<T>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    if (response.Content.ReadAsStringAsync().Result != String.Empty && response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var error = JsonConvert.DeserializeObject<Error>(response.Content.ReadAsStringAsync().Result);
                        throw new RestClientException(error.error);
                    }
                    else if (response.Content.ReadAsStringAsync().Result != String.Empty && response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new RestClientException("Ошибка авторизации веб-сервиса");
                    }
                    else
                    {
                        throw new RestClientException("При выполнении запроса произошла ошибка");
                    }
                }
            }
        }

        public virtual IResponse Post(IEntity entity)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                    System.Text.ASCIIEncoding.ASCII.GetBytes(
                $"{login}:{password}")));
                var response = client.PostAsync(this.url, new StringContent(entity.ToJson())).Result;
                if (response.IsSuccessStatusCode)
                {
                    return new Response(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    if (response.Content.ReadAsStringAsync().Result != String.Empty && response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var error = JsonConvert.DeserializeObject<Error>(response.Content.ReadAsStringAsync().Result);
                        throw new RestClientException(error.error);
                    }
                    else if (response.Content.ReadAsStringAsync().Result != String.Empty && response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new RestClientException("Ошибка авторизации веб-сервиса");
                    }
                    else
                    {
                        throw new RestClientException("При выполнении запроса произошла ошибка");
                    }
                }
            }
        }

        public virtual IResponse Put(int id, IEntity entity)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                    System.Text.ASCIIEncoding.ASCII.GetBytes(
                $"{login}:{password}")));
                var response = client.PutAsync(this.url+id.ToString(), new StringContent(entity.ToJson())).Result;
                if (response.IsSuccessStatusCode)
                {
                    return new Response(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    if (response.Content.ReadAsStringAsync().Result != String.Empty && response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var errors = JsonConvert.DeserializeObject<Error>(response.Content.ReadAsStringAsync().Result);
                        throw new RestClientException(errors.error);
                    }
                    else if (response.Content.ReadAsStringAsync().Result != String.Empty && response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new RestClientException("Ошибка авторизации веб-сервиса");
                    }
                    else
                    {
                        throw new RestClientException("При выполнении запроса произошла ошибка");
                    }
                }
            }
        }

        public virtual IResponse Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
                    "Basic", Convert.ToBase64String(
                    System.Text.ASCIIEncoding.ASCII.GetBytes(
                $"{login}:{password}")));
                var response = client.DeleteAsync(this.url+id.ToString()).Result;
                if (response.IsSuccessStatusCode)
                {
                    return new Response(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    if (response.Content.ReadAsStringAsync().Result != String.Empty && response.StatusCode == HttpStatusCode.BadRequest)
                    {
                        var errors = JsonConvert.DeserializeObject<Error>(response.Content.ReadAsStringAsync().Result);
                        throw new RestClientException(errors.error);
                    }
                    else if (response.Content.ReadAsStringAsync().Result != String.Empty && response.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        throw new RestClientException("Ошибка авторизации веб-сервиса");
                    }
                    else
                    {
                        throw new RestClientException("При выполнении запроса произошла ошибка");
                    }
                }
            }
        }


    }
}
