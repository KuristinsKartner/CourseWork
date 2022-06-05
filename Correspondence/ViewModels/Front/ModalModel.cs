using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.ViewModels
{
    public class ModalModel
    {
        public int? Id { get; set; }
        public string Author { get; set; }
        public string Folder { get; set; }
        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string Events { get; set; }
        public string Subevent { get; set; }
        public string Theme { get; set; }
        public string Subtheme { get; set; }
        public string Place { get; set; }
        public bool NoPublic { get; set; }
        public string Comment { get; set; }
        public string Scan_name { get; set; }
        public string Format_name { get; set; }
        public string Sverst_name { get; set; }
        public IFormFile File_scan { get; set; }
        public IFormFile File_format { get; set; }
        public IFormFile File_sverst { get; set; }
        public string DtypeId { get; set; }
        public List<SelectListItem> Options { get; set; }

        public void Clear()
        {
            Id = null;
            Author = null;
            Folder = null;
            Day = null;
            Month = null;
            Year = null;
            Events = null;
            Place = null;
            Subevent = null;
            Subtheme = null;
            Theme = null;
            NoPublic = false;
            var dtype = Options.Where(o => o.Selected == true).FirstOrDefault();
            if (dtype != null)
                dtype.Selected = false;
            DtypeId = null;
            Scan_name = null;
            Format_name = null;
            Sverst_name = null;
            File_scan = null;
            File_format = null;
            File_sverst = null;
            Comment = null;
        }

    }
}
