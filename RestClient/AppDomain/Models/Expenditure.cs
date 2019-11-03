using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestClient.AppDomain.Interfaces;
namespace RestClient.AppDomain.Models
{
    public class Expenditure : IEntity
    {
        public string frc_id;
        public string frc_name;
        public string budget_project_id;
        public string budget_project_name;
        public string budget_item_id;
        public string budget_item_name;
        public string total_amount;
    }
}
