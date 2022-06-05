using Correspondence.Interfaces;
using Correspondence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.Services
{
    public class PlaceService : IPlaceService
    {
        private CorrespContext context;
        
        public PlaceService(CorrespContext context)
        {
            this.context = context;
        }
       
        public bool PlaceExist(string name)
        {
            var existing_Place = context.Places.Where(c => c.FullPlace == name).FirstOrDefault();
            return existing_Place != null;
        }
        public string FindById(int? id)
        {
            var existing = context.Places.Where(c => c.Id == id).FirstOrDefault();
            return existing?.FullPlace;
        }
        public bool Remove(int? id)
        {
            var delete = context.Places.Where(d => d.Id == id).FirstOrDefault(); 
            if (delete != null)
            {
                context.Places.Remove(delete);
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetId(string name)
        {
            if (PlaceExist(name))
            {
                var GetID = context.Places.Where(c => c.FullPlace == name).FirstOrDefault();
                return GetID.Id;
            }
            else
                return 0;
        }
        public bool AddPlace(string name)
        {
            if (!PlaceExist(name))
            {
                context.Places.Add(new Place() { FullPlace = FirstCharToUpper(name) });
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
