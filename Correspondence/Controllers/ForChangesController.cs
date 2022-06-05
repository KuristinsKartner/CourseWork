using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Correspondence.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Correspondence.Models;
using Correspondence.ViewModels;

namespace Correspondence.Controllers
{
    public class ForChangesController : Controller
    {
        public IActionResult Index()
        {
            return View();
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
        public ForChangesController(IAuthorService authorService, IDtypeService dtypeService, IEventService eventService, IMainService mainService,
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

        public IActionResult GetRecord(int? required_id)
        {
            var model = new GetRecordViewModel();
            if (required_id != null)
            {
                Main main = _mainService.GetInfoById(required_id);
                if (main != null)
                {
                    model.Id = required_id;
                    ViewBag.Day = main.Day;
                    ViewBag.Month = main.Month;
                    ViewBag.Year = main.Year;
                    ViewBag.Folder = main.Folder;
                    ViewBag.NoPublic = main.NoPublic;
                    ViewBag.Comment = main.Comments;
                    model.Options = _mainService.AddDTypesToList();
                    ViewBag.Author = _authorService.FindById(main.IdAuthor);
                    ViewBag.Event = _eventService.FindById(main.IdEvent);
                    ViewBag.Place = _placeService.FindById(main.IdPlace);
                    ViewBag.Subevent = _subeventService.FindById(main.IdSubevent);
                    ViewBag.Subtheme = _subthemeService.FindById(main.IdSubtheme);
                    ViewBag.Theme = _themeService.FindById(main.IdTheme);
                    model.Options.Find(o => o.Value == main.IdDtype.ToString()).Selected = true;
                    return View(model);
                }
                else
                {
                    ViewBag.Id = "Запись не найдена";
                    return View("Error");
                }
            }
            return View("Error");
        }
        [HttpPost]
        [ActionName("FindPost")]
        public IActionResult OnPost(int? required_id)
        {
            var model = new GetRecordViewModel();
            if (required_id != null)
            {
                Main main = _mainService.GetInfoById(required_id);
                if (main != null)
                {
                    model.Id = required_id;
                    ViewBag.Day = main.Day;
                    ViewBag.Month = main.Month;
                    ViewBag.Year = main.Year;
                    ViewBag.Folder = main.Folder;
                    ViewBag.NoPublic = main.NoPublic;
                    ViewBag.Comment = main.Comments;
                    model.Options = _mainService.AddDTypesToList();
                    ViewBag.Author = _authorService.FindById(main.IdAuthor);
                    ViewBag.Event = _eventService.FindById(main.IdEvent);
                    ViewBag.Place = _placeService.FindById(main.IdPlace);
                    ViewBag.Subevent = _subeventService.FindById(main.IdSubevent);
                    ViewBag.Subtheme = _subthemeService.FindById(main.IdSubtheme);
                    ViewBag.Theme = _themeService.FindById(main.IdTheme);
                    model.Options.Find(o => o.Value == main.IdDtype.ToString()).Selected = true;
                    return View(model);
                }
                else
                {
                    ViewBag.Id = "Запись не найдена";
                    return View("Error");
                }
            }
            return View("Error");
        }

        [HttpPost]
        [ActionName("SavePost")]
        public IActionResult OnPost(string author, int? day, int? month, int? year, string events, string plus_event,
                           string topic, string plus_topic, string folder, string place, string DtypeId,
                           string comment, bool custom_checkbox, IFormFile file_scan, IFormFile file_format, IFormFile file_sverst, GetRecordViewModel model)
        {
            int? i = model.Id;
            if (model.Id > 0)
            {
                Main main = _mainService.GetInfoById(model.Id);
                //////////////////////////////////////////////////////////// перезапись файлов
                if (file_scan != null)
                {
                    _filesService.RewriteScan(main.IdFiles, file_scan);
                }
                if (file_format != null)
                {
                    _filesService.RewriteFormat(main.IdFiles, file_format);
                }
                if (file_sverst != null)
                {
                    _filesService.RewriteSverst(main.IdFiles, file_sverst);
                }
                //////////////////////////////////////////////////////////// проверка автора
                if (main.IdAuthor != null)//Если у записи присутствует автор
                {
                    if (author != _authorService.FindById(main.IdAuthor))//Если введенный пользователем автор не совпадает с исходным
                    {
                        if (_mainService.CountMainsWithAuthorId(main.IdAuthor) <= 1) //Если этот автор больше не упоминается в других записях
                        {
                            _authorService.Remove(main.IdAuthor);//Удаляем автора
                        }
                    }
                }
                if (author != null) //Если поле автора не пустое
                {
                    if (_authorService.AddAuthor(author) == true) // Если новый автор добавляется
                    {
                        _mainService.ConnectLocalAuthor(author, model.Id); //Соединяем запись с локальной коллекцией
                    }
                    else
                    {
                        _mainService.ConnectGlobalAuthor(author, model.Id); //Соединяем с глобальной коллекцией
                    }
                }
                else
                {
                    main.IdAuthor = null;
                }
                //////////////////////////////////////////////////////////// проверка события
                if (main.IdEvent != null)
                {
                    if (events != _eventService.FindById(main.IdEvent))
                    {
                        if (_mainService.CountMainsWithEventId(main.IdEvent) <= 1)
                        {
                            _eventService.Remove(main.IdEvent);
                        }
                    }
                }
                if (events != null)
                {
                    if (_eventService.AddEvent(events) == true)
                    {
                        _mainService.ConnectLocalEvent(events, model.Id);
                    }
                    else
                    {
                        _mainService.ConnectGlobalEvent(events, model.Id);
                    }
                }
                else
                {
                    main.IdEvent = null;
                }
                //////////////////////////////////////////////////////////// проверка местоположения
                if (main.IdPlace != 0)
                {
                    int tempid = main.IdPlace;
                    if (place != _placeService.FindById(main.IdPlace))
                    {
                        if (place != null)
                        {
                            if (_placeService.AddPlace(place) == true)
                            {
                                _mainService.ConnectLocalPlace(place, model.Id);
                            }
                            else
                            {
                                _mainService.ConnectGlobalPlace(place, model.Id);
                            }
                        }
                        if (_mainService.CountMainsWithPlaceId(tempid) <= 1) //Местоположения обязательное поле
                        {
                            _placeService.Remove(tempid);
                        }
                    }
                }

                //////////////////////////////////////////////////////////// проверка подсобытия
                if (main.IdSubevent != null)
                {
                    if (plus_event != _subeventService.FindById(main.IdSubevent))
                    {
                        if (_mainService.CountMainsWithSubeventId(main.IdSubevent) <= 1)
                        {
                            _subeventService.Remove(main.IdSubevent);
                        }
                    }
                }
                if (plus_event != null)
                {
                    if (_subeventService.AddSubevent(plus_event) == true)
                    {
                        _mainService.ConnectLocalSubevent(plus_event, model.Id);
                    }
                    else
                    {
                        _mainService.ConnectGlobalSubevent(plus_event, model.Id);
                    }
                }
                else
                {
                    main.IdSubevent = null;
                }
                //////////////////////////////////////////////////////////// проверка подтемы
                if (main.IdSubtheme != null)
                {
                    if (plus_topic != _subthemeService.FindById(main.IdSubtheme))
                    {
                        if (_mainService.CountMainsWithSubthemeId(main.IdSubtheme) <= 1)
                        {
                            _subthemeService.Remove(main.IdSubtheme);
                        }
                    }
                }
                if (plus_topic != null)
                {
                    if (_subthemeService.AddSubtheme(plus_topic) == true)
                    {
                        _mainService.ConnectLocalSubtheme(plus_topic, model.Id);
                    }
                    else
                    {
                        _mainService.ConnectGlobalSubtheme(plus_topic, model.Id);
                    }
                }
                else
                {
                    main.IdSubtheme = null;
                }
                //////////////////////////////////////////////////////////// проверка темы
                if (main.IdTheme != null)
                {
                    if (topic != _themeService.FindById(main.IdTheme))
                    {
                        if (_mainService.CountMainsWithSubthemeId(main.IdTheme) <= 1)
                        {
                            _themeService.Remove(main.IdTheme);
                        }
                    }
                }
                if (topic != null)
                {
                    if (_themeService.AddTheme(topic) == true)
                    {
                        _mainService.ConnectLocalTheme(topic, model.Id);
                    }
                    else
                    {
                        _mainService.ConnectGlobalTheme(topic, model.Id);
                    }
                }
                else
                {
                    main.IdTheme = null;
                }
                /////////////////////////////////////////////////////////// проверка полной даты
                bool Fdate = ((day != null) && (month != null) && (year != null)) ? true : false;
                if (Fdate != main.FDate)
                {
                    main.FDate = Fdate;
                }
                /////////////////////////////////////////////////////////// установка даты
                if (day != main.Day)
                {
                    main.Day = day;
                }
                if (month != main.Month)
                {
                    main.Month = month;
                }
                if (year != main.Year)
                {
                    main.Year = year;
                }
                /////////////////////////////////////////////////////////// установка типа данных
                if (int.Parse(DtypeId) != main.IdDtype)
                {
                    main.IdDtype = int.Parse(DtypeId);
                }
                /////////////////////////////////////////////////////////// установка папки
                if (folder != main.Folder)
                {
                    main.Folder = folder;
                }
                /////////////////////////////////////////////////////////// установка публичности
                if (custom_checkbox != main.NoPublic)
                {
                    main.NoPublic = custom_checkbox;
                }
                if (comment != main.Comments)
                {
                    main.Comments = comment;
                }
                /////////////////////////////////////////////////////////// Сохранение изменений
                _mainService.SaveAll();
                return RedirectToAction("Index");
            }
            return View("404 not found");
        }


        [HttpPost]
        [ActionName("DeletePost")]
        public IActionResult OnPost(int? required_id, GetRecordViewModel model)
        {
            if (model.Id > 0)
            {
                Main main = _mainService.GetInfoById(model.Id);
                _mainService.Remove(model.Id);
                if (_mainService.CountMainsWithAuthorId(main.IdAuthor) <= 1)
                {
                    _authorService.Remove(main.IdAuthor);
                }
                if (_mainService.CountMainsWithEventId(main.IdEvent) <= 1)
                {
                    _eventService.Remove(main.IdEvent);
                }
                if (_mainService.CountMainsWithPlaceId(main.IdPlace) <= 1)
                {
                    _placeService.Remove(main.IdPlace);
                }
                if (_mainService.CountMainsWithSubeventId(main.IdSubevent) <= 1)
                {
                    _subeventService.Remove(main.IdSubevent);
                }
                if (_mainService.CountMainsWithSubthemeId(main.IdSubtheme) <= 1)
                {
                    _subthemeService.Remove(main.IdSubtheme);
                }
                if (_mainService.CountMainsWithThemeId(main.IdTheme) <= 1)
                {
                    _themeService.Remove(main.IdTheme);
                }
                _mainService.SaveAll();
                return RedirectToAction("Index");
            }
            return View("404 not found");
            
        }
    }
}
