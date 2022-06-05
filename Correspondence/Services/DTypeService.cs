using Correspondence.Interfaces;
using Correspondence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.Services
{
    public class DTypeService : IDtypeService
    {
        private CorrespContext context;
        
        public DTypeService(CorrespContext context)
        {
            this.context = context;
        }
       
        public List<Dtype> GetAllDTypes()
        {
            List<Dtype> list = new List<Dtype>();
            var dtypes = context.Dtypes.Select(c => new {
                id = c.Id,
                name = c.Name
            });
            foreach (var names in dtypes)
                list.Add(new Dtype() { Id = names.id, Name = names.name });
            return list;
        }
    }
}
