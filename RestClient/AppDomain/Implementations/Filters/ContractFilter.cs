using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestClient.AppDomain.Interfaces;
namespace RestClient.AppDomain.Implementations.Filters
{
    public class ContractFilter : IFilter
    {
        public string ContractorId;
        public string CurrencyCode;
        public string OurOrganisationINN;
        public string OurOrganisationKPP;
        public string BuildQueryString()
        {
            return String.Format("{0}/{1}/{2}/{3}", ContractorId, CurrencyCode, OurOrganisationINN, OurOrganisationKPP);
        }
    }
}
