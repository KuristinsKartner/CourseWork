using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.ViewModels
{
    public class FilterModel
    {
        public int? ID { get; set; }
        public string Author { get; set; }
        public string Folder { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
        public int MinRange { get; set; }
        public string Events { get; set; }
        public string Subevent { get; set; }
        public string Theme { get; set; }
        public string Subtheme { get; set; }
        public string Place { get; set; }
        public string DtypeId { get; set; }

        public List<SelectListItem> Options { get; set; }
    }
}
