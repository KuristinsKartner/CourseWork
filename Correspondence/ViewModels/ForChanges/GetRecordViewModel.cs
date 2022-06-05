using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.ViewModels
{
    public class GetRecordViewModel
    {
        public int? Id { get; set; } 
        public List<SelectListItem> Options { get; set; }
    }
}
