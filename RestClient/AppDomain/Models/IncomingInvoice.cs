using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestClient.AppDomain.Models;
using RestClient.AppDomain.Interfaces;
namespace RestClient.AppDomain.Models
{
    public class IncomingInvoice : IEntity
    {
        public string id;
        public string name;
        public string description;
        public string invoice_number;
        public string invoice_date;
        public string total_amount;
        public string currency;
        public string VAT;
        public string contractor_id;
        public string contractor_name;
        public string contract_id;
        public string contract_name;
        public string our_organisation_inn;
        public string our_organisation_kpp;
        public List<Expenditure> expenditures;
    }
}
