using Correspondence.Interfaces;
using Correspondence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.Services
{
    public class ThemeService : IThemeService
    {
        private CorrespContext context;
        
        public ThemeService(CorrespContext context)
        {
            this.context = context;
        }
       
        public bool ThemeExist(string name)
        {
            var existing_Theme = this.context.Themes.Where(c => c.Name == name).FirstOrDefault();
            return existing_Theme != null;
        }
        public string FindById(int? id)
        {
            var existing = context.Themes.Where(c => c.Id == id).FirstOrDefault();
            return existing?.Name;
        }
        public bool Remove(int? id)
        {
            var delete = context.Themes.Where(d => d.Id == id).FirstOrDefault();
            if (delete != null)
            {
                context.Themes.Remove(delete);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int? GetId(string name)
        {
            if (ThemeExist(name))
            {
                var GetID = this.context.Themes.Where(c => c.Name == name).FirstOrDefault();
                return GetID.Id;
            }
            else
                return null;
        }
        public bool AddTheme(string name)
        {
            if (!ThemeExist(name))
            {
                context.Themes.Add(new Theme() { Name = FirstCharToUpper(name) });
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
