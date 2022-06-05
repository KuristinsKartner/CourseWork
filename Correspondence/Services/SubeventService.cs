using Correspondence.Interfaces;
using Correspondence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.Services
{
    public class SubeventService : ISubeventService
    {
        private CorrespContext context;
        
        public SubeventService(CorrespContext context)
        {
            this.context = context;
        }
       
        public bool SubeventExist(string name)
        {
            var existing_Subevent = context.Subevents.Where(c => c.Name == name).FirstOrDefault();
            return existing_Subevent != null;
        }
        public string FindById(int? id)
        {
            var existing = context.Subevents.Where(c => c.Id == id).FirstOrDefault();
            return existing?.Name;
        }
        public bool Remove(int? id)
        {
            var delete = context.Subevents.Where(d => d.Id == id).FirstOrDefault();
            if (delete != null)
            {
                context.Subevents.Remove(delete);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int? GetId(string name)
        {
            if (SubeventExist(name))
            {
                int id = 0;
                var GetID = context.Subevents.Where(c => c.Name == name);
                foreach (Subevent c in GetID)
                    id = c.Id;
                return id;
            }
            else
                return null;
        }
        public bool AddSubevent(string name)
        {
            if (!SubeventExist(name))
            {
                context.Subevents.Add(new Subevent() { Name = FirstCharToUpper(name) });
                return true;
            }
            else
                return false;
        }
        public string FirstCharToUpper(string input)
        {
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }
    }
}
