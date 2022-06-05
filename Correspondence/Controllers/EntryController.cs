using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.Controllers
{
    public class EntryController : Controller
    {
        public IActionResult EntryIndex()
        {
            return View();
        }
    }
}
