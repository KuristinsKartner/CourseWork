using Correspondence.Interfaces;
using Correspondence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.Services
{
    public class SubthemeService : ISubthemeService
    {
        private CorrespContext context;
        
        public SubthemeService(CorrespContext context)
        {
            this.context = context;
        }
        
        public bool SubthemeExist(string name)
        {
            var existing_Subtheme = context.Subthemes.Where(c => c.Name == name).FirstOrDefault();
            return existing_Subtheme != null;
        }
        public string FindById(int? id)
        {
            var existing = context.Subthemes.Where(c => c.Id == id).FirstOrDefault();
            return existing?.Name;
        }
        public bool Remove(int? id)
        {
            var delete = context.Subthemes.Where(d => d.Id == id).FirstOrDefault(); 
            if (delete != null)
            {
                context.Subthemes.Remove(delete);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int? GetId(string name)
        {
            if (SubthemeExist(name))
            {
                var GetID = context.Subthemes.Where(c => c.Name == name).FirstOrDefault();
                return GetID.Id;
            }
            else
                return null;
        }
        public bool AddSubtheme(string name)
        {
            if (SubthemeExist(name))
            {
                context.Subthemes.Add(new Subtheme() { Name = FirstCharToUpper(name) });
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
