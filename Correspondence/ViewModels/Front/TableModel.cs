using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.ViewModels
{
    public class TableModel
    {
        public bool Checked { get; set; }
        public int Id { get; set; }
        public string Date { get; set; }
        public string Folder { get; set; }
        public bool NoPublic { get; set; }
        public string Author { get; set; }
        public string Event { get; set; }
        public string Subevent { get; set; }
        public string Theme { get; set; }
        public string Subtheme { get; set; }
        public string Place { get; set; }
        public int IdFiles { get; set; }

        static public int AllAuthor { get; set; }
    }
}
