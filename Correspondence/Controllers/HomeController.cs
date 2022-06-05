using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Correspondence.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Correspondence.ViewModels;


namespace Correspondence.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var model = new IndexViewModel();
            ViewBag.Message = _mainService.LastID() + 1;
            model.Options = _mainService.AddDTypesToList();
            return View(model);
        }

        private readonly IAuthorService _authorService;
        private readonly IDtypeService _dtypeService;
        private readonly IEventService _eventService;
        private readonly IMainService _mainService;
        private readonly IPlaceService _placeService;
        private readonly ISubeventService _subeventService;
        private readonly ISubthemeService _subthemeService;
        private readonly IThemeService _themeService;
        private readonly IFilesService _filesService;
        public List<SelectListItem> Options { get; set; }

        public HomeController(IAuthorService authorService, IDtypeService dtypeService, IEventService eventService, IMainService mainService,
                          IPlaceService placeService, ISubeventService subeventService, ISubthemeService subthemeService, IThemeService themeService,
                          IFilesService filesService)
        {
            _authorService = authorService;
            _dtypeService = dtypeService;
            _eventService = eventService;
            _mainService = mainService;
            _placeService = placeService;
            _subeventService = subeventService;
            _subthemeService = subthemeService;
            _themeService = themeService;
            _filesService = filesService;

        }

 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult OnPostMyFile(string author, int? day, int? month, int? year, string events, string plus_event,
                           string topic, string plus_topic, string folder, string place, string DtypeId,
                           string comment, bool custom_checkbox, IFormFile file_scan, IFormFile file_format, IFormFile file_sverst)
        {

            bool flag = false;
            if (author != null)
            {
                if (_authorService.AddAuthor(author) == true)
                {
                    flag = true;
                }
            }
            if (events != null)
            {
                if (_eventService.AddEvent(events) == true)
                {
                    flag = true;
                }
            }
            if (plus_event != null)
            {
                if (_subeventService.AddSubevent(plus_event) == true)
                {
                    flag = true;
                }
            }
            if (topic != null)
            {
                if (_themeService.AddTheme(topic) == true)
                {
                    flag = true;
                }
            }
            if (plus_topic != null)
            {
                if (_subthemeService.AddSubtheme(plus_topic) == true)
                {
                    flag = true;
                }
            }
            if (place != null)
            {
                if (_placeService.AddPlace(place) == true)
                {
                    flag = true;
                }
            }
            if (flag == true)
            {
                _mainService.SaveAll();
            }
            _filesService.AddFiles(file_scan, file_format, file_sverst);
            int? authorID = _authorService.GetId(author);
            int? eventID = _eventService.GetId(events);
            int? subeventID = _subeventService.GetId(plus_event);
            int? themeId = _themeService.GetId(topic);
            int? subthemeID = _subthemeService.GetId(plus_topic);
            int placeID = _placeService.GetId(place);
            bool Fdate = ((day != null) && (month != null) && (year != null)) ? true : false;
            _mainService.SetData(authorID, int.Parse(DtypeId), eventID, subeventID, themeId, subthemeID,
                                    placeID, day, month, year, folder, comment, custom_checkbox, Fdate);
            _mainService.SaveAll();
            return RedirectToAction("Index");
        }

    }
}
