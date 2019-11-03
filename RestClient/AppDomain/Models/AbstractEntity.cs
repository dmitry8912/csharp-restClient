﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestClient.AppDomain.Interfaces;
namespace RestClient.AppDomain.Models
{
    public abstract class AbstractEntity : IEntity
    {
        public string id;
        public string name;
    }
}
