using Correspondence.Interfaces;
using Correspondence.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using System.Net.Mime;
using Correspondence.Models;

namespace Correspondence.Controllers
{
    public class FrontController : Controller
    {
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
        private ViewModel model = new ViewModel();

        public FrontController(IAuthorService authorService, IDtypeService dtypeService, IEventService eventService, IMainService mainService,
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
        public IActionResult ClearFilter()
        {
            model = JsonSerializer.Deserialize<ViewModel>(HttpContext.Session.GetString("model"));
            model.Filter.ID = null;
            model.Filter.Author = null;
            model.Filter.MinYear = model.Filter.MinRange;
            model.Filter.MaxYear = DateTime.Now.Year;
            model.Filter.DtypeId = null;
            model.Filter.Events = null;
            model.Filter.Folder = null;
            model.Filter.Place = null;
            model.Filter.Subevent = null;
            model.Filter.Subtheme = null;
            model.Filter.Theme = null;
            var dtype = model.Filter.Options.Where(o => o.Selected == true).FirstOrDefault();
            if (dtype != null)
                dtype.Selected = false;
            model.Table = _mainService.GetAllRecord();
            model.Sort.Select("asc", "author");
            HttpContext.Session.SetString("model", JsonSerializer.Serialize(model));
            return Redirect("../");
        }
        public IActionResult FrontIndex()
        {
            if (HttpContext.Session.GetString("model") == null)
            {
                model.Table = _mainService.GetAllRecord();
                model.Sort.InitLists();
                model.Sort.Select("asc", "author");
                model.Filter.MinRange = 1900;
                model.Filter.MinYear = model.Filter.MinRange;
                model.Filter.MaxYear = DateTime.Now.Year;
                model.Filter.Options = _mainService.AddDTypesToList();
                model.Modal.Options = _mainService.AddDTypesToList();
            }
            else
            {
                model = JsonSerializer.Deserialize<ViewModel>(HttpContext.Session.GetString("model"));
            }
            model.Table = _mainService.Sorting(model.Table, model.Sort.GetSelectedExpression(), model.Sort.GetSelectedField());
            HttpContext.Session.SetString("model", JsonSerializer.Serialize(model));
            return View(model);
        }
        [HttpPost]
        public void SetFilter(FilterModel filter, string date)
        {
            model = JsonSerializer.Deserialize<ViewModel>(HttpContext.Session.GetString("model"));
            model.Filter.ID = filter.ID;
            model.Filter.Author = filter.Author;
            model.Filter.MinYear = int.Parse(date.Substring(0, 4));
            model.Filter.MaxYear = int.Parse(date.Substring(7, 4));
            model.Filter.DtypeId = filter.DtypeId;
            model.Filter.Events = filter.Events;
            model.Filter.Folder = filter.Folder;
            model.Filter.Place = filter.Place;
            model.Filter.Subevent = filter.Subevent;
            model.Filter.Subtheme = filter.Subtheme;
            model.Filter.Theme = filter.Theme;
            if (filter.DtypeId != null)
            {
                var selected = model.Filter.Options.Where(o => o.Selected).FirstOrDefault();
                if (selected != null)
                    selected.Selected = false;
                model.Filter.Options.Where(o => o.Value == filter.DtypeId).FirstOrDefault().Selected = true;
            }
            model.Table = _mainService.GetAllRecordWithFilter(model.Filter);
            HttpContext.Session.SetString("model", JsonSerializer.Serialize(model));
        }
        [HttpPost]
        public void Sorting(string field, string expression)
        {
            model = JsonSerializer.Deserialize<ViewModel>(HttpContext.Session.GetString("model"));
            model.Sort.Select(expression, field);
            HttpContext.Session.SetString("model", JsonSerializer.Serialize(model));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("AddRecord")]
        public void AddRecord(ModalModel Add)
        {
            bool flag = false;
            if (Add.Author != null)
                flag = flag || _authorService.AddAuthor(Add.Author);
            if (Add.Events != null)
                flag = flag || _eventService.AddEvent(Add.Events);
            if (Add.Subevent != null)
                flag = flag || _subeventService.AddSubevent(Add.Subevent);
            if (Add.Theme != null)
                flag = flag || _themeService.AddTheme(Add.Theme);
            if (Add.Subtheme != null)
                flag = flag || _subthemeService.AddSubtheme(Add.Subtheme);
            if (Add.Place != null)
                flag = flag || _placeService.AddPlace(Add.Place);
            if (flag)
                _mainService.SaveAll();
            int? authorID = _authorService.GetId(Add.Author);
            int? eventID = _eventService.GetId(Add.Events);
            int? subeventID = _subeventService.GetId(Add.Subevent);
            int? themeId = _themeService.GetId(Add.Theme);
            int? subthemeID = _subthemeService.GetId(Add.Subtheme);
            int placeID = _placeService.GetId(Add.Place);
            bool Fdate = (Add.Day != null) && (Add.Month != null) && (Add.Year != null);
            _filesService.AddFiles(Add.File_scan, Add.File_format, Add.File_sverst);
            _mainService.SetData(authorID, int.Parse(Add.DtypeId), eventID, subeventID, themeId, subthemeID,
                                    placeID, Add.Day, Add.Month, Add.Year, Add.Folder, Add.Comment, Add.NoPublic, Fdate);
            _mainService.SaveAll();
            model = JsonSerializer.Deserialize<ViewModel>(HttpContext.Session.GetString("model"));
            model.Table = _mainService.GetAllRecordWithFilter(model.Filter);
            model.Modal.Clear();
            HttpContext.Session.SetString("model", JsonSerializer.Serialize(model));
        }
        [HttpPut]
        public IActionResult InfoModal(int id)
        {
            model = JsonSerializer.Deserialize<ViewModel>(HttpContext.Session.GetString("model"));
            model.Modal = _mainService.ParseToModalModel(_mainService.GetInfoById(id));
            HttpContext.Session.SetString("model", JsonSerializer.Serialize(model));
            return Json(model.Modal);
        }

        [HttpGet]
        public IActionResult DownloadFile(int id, string name)
        {
            Files files = _filesService.GetFiles(id);
            FileContentResult response;
            switch (name)
            {
                case "file_scan":
                    if (files.ScanData != null)
                    {
                        response = new FileContentResult(files.ScanData, "multipart/form-data");
                        response.FileDownloadName = files.ScanName + files.ScanExtension;
                    }
                    else
                        response = null;
                    break;
                case "file_format":
                    if (files.FormatData != null)
                    {
                        response = new FileContentResult(files.FormatData, "multipart/form-data");
                        response.FileDownloadName = files.FormatName + files.FormatExtension;
                    }
                    else
                        response = null;
                    break;
                case "file_sverst":
                    if (files.SverstData != null)
                    {
                        response = new FileContentResult(files.SverstData, "multipart/form-data");
                        response.FileDownloadName = files.SverstName + files.SverstExtension;
                    }
                    else
                        response = null;
                    break;
                default:
                    response = null;
                    break;
            }
            return response; //Доделать, чтобы возвращал не нулл
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("EditRecord")]
        public IActionResult EditRecord(ModalModel modal)
        {
            model = JsonSerializer.Deserialize<ViewModel>(HttpContext.Session.GetString("model"));
            _mainService.Edit(modal);
            model.Modal.Clear();
            model.Table = _mainService.GetAllRecordWithFilter(model.Filter);
            HttpContext.Session.SetString("model", JsonSerializer.Serialize(model));
            return Json("Hewllo");
        }
        [HttpPost]
        [ActionName("DeleteRecord")]
        public IActionResult DeleteRecord(int id)
        {
            model = JsonSerializer.Deserialize<ViewModel>(HttpContext.Session.GetString("model"));
            _mainService.Delete(id);
            model.Modal.Clear();
            model.Table = _mainService.GetAllRecordWithFilter(model.Filter);
            HttpContext.Session.SetString("model", JsonSerializer.Serialize(model));
            return Json("hg");
        }
    }
    
}
