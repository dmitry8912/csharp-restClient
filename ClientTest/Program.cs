using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestClient.AppDomain.Implementations;
namespace ClientTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceEntityClient client = new ServiceEntityClient("http://www.mocky.io/v2/5ca9e6733700002b0b492eee");
            var list = client.Get();
            Console.ReadKey();
        }
    }
}
