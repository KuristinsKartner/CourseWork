using Correspondence.Interfaces;
using Correspondence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.Services
{
    public class EventService: IEventService
    {
        private CorrespContext context;
       
        public EventService(CorrespContext context)
        {
            this.context = context;
        }
       
        public bool EventExist(string name)
        {
            var existing_Event = context.Events.Where(c => c.Name == name).FirstOrDefault();
            return existing_Event != null;
        }
        public string FindById(int? id)
        {
            var existing = context.Events.Where(c => c.Id == id).FirstOrDefault();
            return existing?.Name;
        }
        public int? GetId(string name)
        {
            if (EventExist(name))
            {
                var GetID = context.Events.Where(c => c.Name == name).FirstOrDefault();
                return GetID.Id;
            }
            else
                return null;
        }
        public bool Remove(int? id)
        {
            var delete = context.Events.Where(d => d.Id == id).FirstOrDefault();
            if (delete != null)
            {
                context.Events.Remove(delete);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool AddEvent(string name)
        {
            if (!EventExist(name))
            {
                context.Events.Add(new Event() { Name = FirstCharToUpper(name) });
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

