using Correspondence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.Interfaces
{
    public interface ISubeventService
    {
        public bool SubeventExist(string name);
        public int? GetId(string name);
        public bool AddSubevent(string name);
        public string FirstCharToUpper(string input);
        public string FindById(int? id);
        public bool Remove(int? id);

    }
}
