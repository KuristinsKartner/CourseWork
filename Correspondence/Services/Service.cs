using Correspondence.Interfaces;
using Correspondence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.Services
{
    public class Service : IService
    {
        CorrespContext context;
        public Service(CorrespContext context)
        {
            this.context = context;
        }
        
    }
}
