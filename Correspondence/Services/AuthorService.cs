using Correspondence.Interfaces;
using Correspondence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.Services
{
    public class AuthorService : IAuthorService
    {
        private CorrespContext context;
        
        public AuthorService(CorrespContext context)
        {
            this.context = context;
        }
        public string FindById(int? id)
        {
            var existing = context.Authors.Where(c => c.Id == id).FirstOrDefault();
            return existing?.Name;
        }
        public bool AuthorExist(string name)
        {
            var existing_Author = context.Authors.Where(c => c.Name == name).FirstOrDefault();
            return existing_Author != null;
        }
        public bool Remove(int? id)
        {
            var delete = context.Authors.Where(d => d.Id == id).FirstOrDefault();
            if (delete != null)
            {
                var a = context.Authors.Remove(delete);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int? GetId(string name)
        {
            if (AuthorExist(name))
            {
                var GetID = context.Authors.Where(c => c.Name == name).FirstOrDefault();
                return GetID.Id;
            }
            else
                return null;
        }
        public bool AddAuthor(string name)
        {
            if (!AuthorExist(name))
            {
                context.Authors.Add(new Author() { Name = FirstCharToUpper(name) });
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
