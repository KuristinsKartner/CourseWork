using Correspondence.Interfaces;
using Correspondence.Models;
using Correspondence.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mime;
using System.Threading.Tasks;

namespace Correspondence.Services
{
    public class MainService : IMainService
    {
        private CorrespContext context { get; set; }
        public MainService(CorrespContext context)
        {
            this.context = context;
        }
        public bool Remove(int? id)
        {
            if (id != null)
            {
                Main main = context.Mains.Find(id);
                Files files = context.Files.Find(main.IdFiles);
                context.Mains.Remove(main);
                context.Files.Remove(files);
                return true;
            }
            return false;
        }
        public void SaveAll()
        {
            context.SaveChanges();
        }
        public CorrespContext GetContext()
        {
            return this.context;
        }
        public string FirstCharToUpper(string input)
        {
            return input.First().ToString().ToUpper() + String.Join("", input.Skip(1));
        }
        public int? ParseIfNotNullable(string text)
        {
            return text == null ? null : int.Parse(text);
        }
        public List<TableModel> GetAllRecord()
        {
            List<TableModel> list = new List<TableModel>();
            var RecordList = context.Mains.ToList();
            list = ParseToTableModel(RecordList);
            return list;
        }
        public List<SelectListItem> AddDTypesToList()
        {
            List<SelectListItem> Options = context.Dtypes.Select(a => new SelectListItem
            {
                Value = a.Id.ToString(),
                Text = a.Name
            }).ToList();
            return Options;
        }
        public void SetData(int? authorID, int DtypeId, int? eventsID, int? subeventID,
                            int? themeID, int? subthemeID, int placeID,
                            int? day, int? month, int? year, string folder,
                            string comment, bool pub, bool fdate)
        {

            Files files = context.Files.Local.OrderBy(f => f.Id).LastOrDefault();
            folder = FirstCharToUpper(folder);
            context.Mains.Add(new Main()
            {
                FDate = fdate,
                Folder = folder,
                NoPublic = pub,
                IdAuthor = authorID,
                IdDtype = DtypeId,
                IdEvent = eventsID,
                IdSubevent = subeventID,
                IdTheme = themeID,
                IdSubtheme = subthemeID,
                IdPlace = placeID,
                IdFilesNavigation = files,
                Comments = comment,
                Day = day,
                Month = month,
                Year = year
            });
        }
        public void ConnectGlobalAuthor(string name, int? id)
        {
            Author author = null;
            Main main = null;
            var existing_Author = context.Authors.Where(a => a.Name == name);
            foreach (Author a in existing_Author)
                author = a;
            var existing_Main = context.Mains.Where(a => a.Id == id);
            foreach (Main m in existing_Main)
                main = m;
            if ((author != null) && (main != null))
            {
                main.IdAuthorNavigation = author;
            }
        }
        public void ConnectLocalAuthor(string name, int? id)
        {
            Author author = null;
            Main main = null;
            var existing_Author = context.Authors.Local.Where(a => a.Name == name);
            foreach (Author a in existing_Author)
                author = a;
            var existing_Main = context.Mains.Where(a => a.Id == id);
            foreach (Main m in existing_Main)
                main = m;
            if ((author != null) && (main != null))
            {
                main.IdAuthorNavigation = author;
            }
        }
        public void ConnectGlobalEvent(string name, int? id)
        {
            Event current = null;
            Main main = null;
            var existing = context.Events.Where(a => a.Name == name);
            foreach (Event a in existing)
                current = a;
            var existing_Main = context.Mains.Where(a => a.Id == id);
            foreach (Main m in existing_Main)
                main = m;
            if ((current != null) && (main != null))
            {
                main.IdEventNavigation = current;
            }
        }
        public void ConnectLocalEvent(string name, int? id)
        {
            Event current = null;
            Main main = null;
            var existing = context.Events.Local.Where(a => a.Name == name);
            foreach (Event a in existing)
                current = a;
            var existing_Main = context.Mains.Where(a => a.Id == id);
            foreach (Main m in existing_Main)
                main = m;
            if ((current != null) && (main != null))
            {
                main.IdEventNavigation = current;
            }
        }
        public void ConnectGlobalPlace(string name, int? id)
        {
            Place current = null;
            Main main = null;
            var existing = context.Places.Where(a => a.FullPlace == name);
            foreach (Place a in existing)
                current = a;
            var existing_Main = context.Mains.Where(a => a.Id == id);
            foreach (Main m in existing_Main)
                main = m;
            if ((current != null) && (main != null))
            {
                main.IdPlaceNavigation = current;
            }
        }
        public void ConnectLocalPlace(string name, int? id)
        {
            Place current = null;
            Main main = null;
            var existing = context.Places.Local.Where(a => a.FullPlace == name);
            foreach (Place a in existing)
                current = a;
            var existing_Main = context.Mains.Where(a => a.Id == id);
            foreach (Main m in existing_Main)
                main = m;
            if ((current != null) && (main != null))
            {
                main.IdPlaceNavigation = current;
            }
        }
        public void ConnectGlobalSubevent(string name, int? id)
        {
            Subevent current = null;
            Main main = null;
            var existing = context.Subevents.Where(a => a.Name == name);
            foreach (Subevent a in existing)
                current = a;
            var existing_Main = context.Mains.Where(a => a.Id == id);
            foreach (Main m in existing_Main)
                main = m;
            if ((current != null) && (main != null))
            {
                main.IdSubeventNavigation = current;
            }
        }
        public void ConnectLocalSubevent(string name, int? id)
        {
            Subevent current = null;
            Main main = null;
            var existing = context.Subevents.Local.Where(a => a.Name == name);
            foreach (Subevent a in existing)
                current = a;
            var existing_Main = context.Mains.Where(a => a.Id == id);
            foreach (Main m in existing_Main)
                main = m;
            if ((current != null) && (main != null))
            {
                main.IdSubeventNavigation = current;
            }
        }
        public void ConnectGlobalSubtheme(string name, int? id)
        {
            Subtheme current = null;
            Main main = null;
            var existing = context.Subthemes.Where(a => a.Name == name);
            foreach (Subtheme a in existing)
                current = a;
            var existing_Main = context.Mains.Where(a => a.Id == id);
            foreach (Main m in existing_Main)
                main = m;
            if ((current != null) && (main != null))
            {
                main.IdSubthemeNavigation = current;
            }
        }
        public void ConnectLocalSubtheme(string name, int? id)
        {
            Subtheme current = null;
            Main main = null;
            var existing = context.Subthemes.Local.Where(a => a.Name == name);
            foreach (Subtheme a in existing)
                current = a;
            var existing_Main = context.Mains.Where(a => a.Id == id);
            foreach (Main m in existing_Main)
                main = m;
            if ((current != null) && (main != null))
            {
                main.IdSubthemeNavigation = current;
            }
        }
        public void ConnectGlobalTheme(string name, int? id)
        {
            Theme current = null;
            Main main = null;
            var existing = context.Themes.Where(a => a.Name == name);
            foreach (Theme a in existing)
                current = a;
            var existing_Main = context.Mains.Where(a => a.Id == id);
            foreach (Main m in existing_Main)
                main = m;
            if ((current != null) && (main != null))
            {
                main.IdThemeNavigation = current;
            }
        }
        public void ConnectLocalTheme(string name, int? id)
        {
            Theme current = null;
            Main main = null;
            var existing = context.Themes.Local.Where(a => a.Name == name);
            foreach (Theme a in existing)
                current = a;
            var existing_Main = context.Mains.Where(a => a.Id == id);
            foreach (Main m in existing_Main)
                main = m;
            if ((current != null) && (main != null))
            {
                main.IdThemeNavigation = current;
            }
        }
        public int LastID()
        {
            int id = 0;
            var GetID = context.Mains.OrderBy(m => m.Id).LastOrDefault();
            if (GetID != null)
            {
                id = GetID.Id;
                return id;
            }
            else
            {
                return 0;
            }

        }
        public Main GetInfoById(int? id)
        {
            Main main = context.Mains.Find(id);
            return main ?? null;

        }
        public int CountMainsWithAuthorId(int? id)
        {
            return context.Mains.Where(m => m.IdAuthor == id).Count();
        }
        public int CountMainsWithEventId(int? id)
        {
            return context.Mains.Where(m => m.IdEvent == id).Count();
        }
        public int CountMainsWithPlaceId(int? id)
        {
            return context.Mains.Where(m => m.IdPlace == id).Count();
        }
        public int CountMainsWithSubeventId(int? id)
        {
            return context.Mains.Where(m => m.IdSubevent == id).Count();
        }
        public int CountMainsWithSubthemeId(int? id)
        {
            return context.Mains.Where(m => m.IdSubtheme == id).Count();
        }
        public int CountMainsWithThemeId(int? id)
        {
            return context.Mains.Where(m => m.IdTheme == id).Count();
        }
        public List<TableModel> GetAllRecordWithFilter(FilterModel filter)
        {
            AuthorService _authorservice = new AuthorService(context);
            EventService _eventservice = new EventService(context);
            SubeventService _subeventservice = new SubeventService(context);
            SubthemeService _subthemeservice = new SubthemeService(context);
            ThemeService _themeservice = new ThemeService(context);
            PlaceService _placeservice = new PlaceService(context);
            List<TableModel> list = new List<TableModel>();
            IQueryable<Main> RecordList = context.Mains;
            if (filter.ID != null)
            {
                RecordList = RecordList.Where(r => r.Id == filter.ID);
            }
            if (filter.Author != null)
            {
                RecordList = RecordList.Where(r => r.IdAuthorNavigation.Name.Contains(filter.Author));
            }
            if (filter.Folder != null)
            {
                RecordList = RecordList.Where(r => r.Folder.Contains(filter.Folder));
            }
            if ((filter.MinYear != filter.MinRange) || (filter.MaxYear != DateTime.Now.Year))
            {
                RecordList = RecordList.Where(r => r.Year >= filter.MinYear && r.Year <= filter.MaxYear);
            }
            if (filter.Events != null)
            {
                RecordList = RecordList.Where(r => r.IdEventNavigation.Name.Contains(filter.Events));
            }
            if (filter.Subevent != null)
            {
                RecordList = RecordList.Where(r => r.IdSubeventNavigation.Name.Contains(filter.Subevent));
            }
            if (filter.Theme != null)
            {
                RecordList = RecordList.Where(r => r.IdThemeNavigation.Name.Contains(filter.Theme));
            }
            if (filter.Subtheme != null)
            {
                RecordList = RecordList.Where(r => r.IdSubthemeNavigation.Name.Contains(filter.Subtheme));
            }
            if (filter.DtypeId != null)
            {
                RecordList = RecordList.Where(r => r.IdDtype == int.Parse(filter.DtypeId));
            }
            if (filter.Place != null)
            {
                RecordList = RecordList.Where(r => r.IdPlaceNavigation.FullPlace.Contains(filter.Place));
            }
            var ResultList = RecordList.ToList();
            list = ParseToTableModel(ResultList);
            return list;

        }
        public ModalModel ParseToModalModel(Main record)
        {
            ModalModel modal = new();
            modal.Id = record.Id;
            modal.Day = record.Day == null ? null : record.Day;
            modal.Month = record.Month == null ? null : record.Month;
            modal.Year = record.Year == null ? null : record.Year;
            modal.Author = record.IdAuthor == null ? null : context.Authors.Find(record.IdAuthor).Name;
            modal.Events = record.IdEvent == null ? null : context.Events.Find(record.IdEvent).Name;
            modal.Subevent = record.IdSubevent == null ? null : context.Subevents.Find(record.IdSubevent).Name;
            modal.Place = context.Places.Find(record.IdPlace).FullPlace;
            modal.Theme = record.IdTheme == null ? null : context.Themes.Find(record.IdTheme).Name;
            modal.Subtheme = record.IdSubtheme == null ? null : context.Subthemes.Find(record.IdSubtheme).Name;
            modal.Folder = record.Folder;
            modal.NoPublic = record.NoPublic;
            modal.Comment = record.Comments;
            modal.Options = AddDTypesToList();
            modal.Options.Where(w => w.Value == record.IdDtype.ToString()).FirstOrDefault().Selected = true;
            Files files = context.Files.Find(record.IdFiles);
            modal.Scan_name = files.ScanName;
            modal.Format_name = files.FormatName;
            modal.Sverst_name = files.SverstName;
            return modal;
        }
        public List<TableModel> ParseToTableModel(List<Main> list)
        {
            int _Id, _IdFiles;
            string _Date = "", _Folder, _Author, _Event, _Subevent, _Theme, _Subtheme, _Place;
            bool _NoPublic;
            List<TableModel> result = new List<TableModel>();
            foreach (Main record in list)
            {
                _Id = record.Id;
                _Date += record.Day == null ? "-." : (record.Day < 10? "0"+record.Day.ToString(): record.Day.ToString()) + ".";
                _Date += record.Month == null ? "-." : (record.Month < 10 ? "0" + record.Month.ToString() : record.Month.ToString()) + ".";
                _Date += record.Year == null ? "-." : record.Year.ToString();
                _Folder = record.Folder;
                _NoPublic = record.NoPublic;
                _Author = record.IdAuthor == null ? "" : context.Authors.Find(record.IdAuthor).Name;
                _Event = record.IdEvent == null ? "" : context.Events.Find(record.IdEvent).Name;
                _Subevent = record.IdSubevent == null ? "" : context.Subevents.Find(record.IdSubevent).Name;
                _Place = context.Places.Find(record.IdPlace).FullPlace;
                _Theme = record.IdTheme == null ? "" : context.Themes.Find(record.IdTheme).Name;
                _Subtheme = record.IdSubtheme == null ? "" : context.Subthemes.Find(record.IdSubtheme).Name;
                _IdFiles = record.IdFiles;
                result.Add(new TableModel
                {
                    Checked = false,
                    Id = _Id,
                    Date = _Date,
                    Author = _Author,
                    Event = _Event,
                    Subevent = _Subevent,
                    NoPublic = _NoPublic,
                    Theme = _Theme,
                    Subtheme = _Subtheme,
                    Folder = _Folder,
                    Place = _Place,
                    IdFiles = _IdFiles
                });
                _Date = "";
            }
            return result;
        }
        public List<TableModel> Sorting(List<TableModel> table, string expression, string field)
        {
            switch (field)
            {
                case "id":
                    table = SortingBy(table, expression, o => o.Id);
                    break;
                case "author":
                    table = SortingBy(table, expression, o => o.Author, w => w.Author != "", w => w.Author == "");
                    break;
                case "folder":
                    table = SortingBy(table, expression, o => o.Folder);
                    break;
                case "place":
                    table = SortingBy(table, expression, o => o.Place);
                    break;
                case "date":
                    List<TableModel> result = new();
                    switch (expression)
                    {
                        case "asc":
                            result = table.Where(w => !w.Date.Contains("-")).OrderBy(o => o.Date.Substring(o.Date.LastIndexOf('.') + 1, 4))
                                 .ThenBy(o => o.Date.Substring(o.Date.IndexOf('.') + 1, 2)).ThenBy(o => o.Date.Substring(0, 2)).ToList();
                            result.AddRange(table.Where(w => w.Date.Contains("-")));
                            break;
                        case "desc":
                            result = table.Where(w => !w.Date.Contains("-")).OrderByDescending(o => o.Date.Substring(o.Date.LastIndexOf('.') + 1, 4))
                                 .ThenByDescending(o => o.Date.Substring(o.Date.IndexOf('.') + 1, 2)).ThenByDescending(o => o.Date.Substring(0, 2)).ToList();
                            result.AddRange(table.Where(w => w.Date.Contains("-")));
                            break;
                    }
                    table = result;
                    break;
                case "events":
                    table = SortingBy(table, expression, o => o.Event, w => w.Event != "", w => w.Event == "");
                    break;
                case "subevent":
                    table = SortingBy(table, expression, o => o.Subevent, w => w.Subevent != "", w => w.Subevent == "");
                    break;
                case "theme":
                    table = SortingBy(table, expression, o => o.Theme, w => w.Theme != "", w => w.Theme == "");
                    break;
                case "subtheme":
                    table = SortingBy(table, expression, o => o.Subtheme, w => w.Subtheme != "", w => w.Subtheme == "");
                    break;
            }    
            return table;
        }
        private List<TableModel> SortingBy<T>(List<TableModel> table, string expression, Func<TableModel, T> OrderParam, Func<TableModel, bool> WhereParam, Func<TableModel, bool> WhereParamEmpty)
        {
            List<TableModel> result = new();
            switch (expression) 
            {
                case "asc":
                    result = table.Where(WhereParam).OrderBy(OrderParam).ToList();
                    result.AddRange(table.Where(WhereParamEmpty));
                    break;
                case "desc":
                    result = table.Where(WhereParam).OrderByDescending(OrderParam).ToList();
                    result.AddRange(table.Where(WhereParamEmpty));
                    break;
            }
            return result;
        }
        private List<TableModel> SortingBy<T>(List<TableModel> table, string expression, Func<TableModel, T> OrderParam)
        {
            List<TableModel> result = new();
            result = expression=="asc"? table.OrderBy(OrderParam).ToList() : table.OrderByDescending(OrderParam).ToList();
            return result;
        } 
        public void Edit(ModalModel modal)
        {
            FilesService _filesService = new FilesService(context); 
            Main main = context.Mains.Find(modal.Id);
            //////////////////////////////////////////////////////////// перезапись файлов
            if (modal.File_scan != null)
                _filesService.RewriteScan(main.IdFiles, modal.File_scan);
            if (modal.File_format != null)
                _filesService.RewriteFormat(main.IdFiles, modal.File_format);
            if (modal.File_sverst != null)
                _filesService.RewriteSverst(main.IdFiles, modal.File_sverst);
            //////////////////////////////////////////////////////////// проверка автора
            if (main.IdAuthor != null)//Если у записи присутствует автор
            {
                if (modal.Author != context.Authors.FirstOrDefault(f=>f.Id == main.IdAuthor).Name)
                    if (context.Mains.Count(w => w.IdAuthor == main.IdAuthor) <= 1)
                        context.Authors.Remove(context.Authors.FirstOrDefault(w => w.Id == main.IdAuthor));
            }
            if (modal.Author != null) //Если поле автора не пустое
            {
                var Exist = context.Authors.FirstOrDefault(c => c.Name == modal.Author);
                if (Exist == null)
                {
                    context.Authors.Add(new Author() { Name = FirstCharToUpper(modal.Author) });
                    context.Mains.Find(main.Id).IdAuthorNavigation = context.Authors.Local.FirstOrDefault(a => a.Name == modal.Author);
                }
                else
                    context.Mains.Find(main.Id).IdAuthorNavigation = Exist;
            }
            else
                main.IdAuthor = null;
            //////////////////////////////////////////////////////////// проверка события
            if (main.IdEvent != null)
            {
                if (modal.Events != context.Events.FirstOrDefault(f => f.Id == main.IdEvent).Name)
                    if (context.Mains.Count(w => w.IdEvent == main.IdEvent) <= 1)
                        context.Events.Remove(context.Events.FirstOrDefault(w => w.Id == main.IdEvent));
            }
            if (modal.Events != null) //Если поле не пустое
            {
                var Exist = context.Events.FirstOrDefault(c => c.Name == modal.Events);
                if (Exist == null)
                {
                    context.Events.Add(new Event() { Name = FirstCharToUpper(modal.Events) });
                    context.Mains.Find(main.Id).IdEventNavigation = context.Events.Local.FirstOrDefault(a => a.Name == modal.Events);
                }
                else
                    context.Mains.Find(main.Id).IdEventNavigation = Exist;
            }
            else
                main.IdEvent = null;
            //////////////////////////////////////////////////////////// проверка местоположения
            if (main.IdPlace != 0)
            {
                int tempid = main.IdPlace;
                if (modal.Place != context.Places.FirstOrDefault(f=>f.Id == main.IdPlace).FullPlace)
                {
                    if (modal.Place != null)
                    {
                        var Exist = context.Places.FirstOrDefault(c => c.FullPlace == modal.Place);
                        if (Exist == null)
                        {
                            context.Places.Add(new Place() { FullPlace = modal.Place });
                            context.Mains.Find(main.Id).IdPlaceNavigation = context.Places.Local.FirstOrDefault(a => a.FullPlace == modal.Place);
                        }
                        else
                        {
                            context.Mains.Find(main.Id).IdPlaceNavigation = Exist;
                        }

                    }
                    if (context.Mains.Count(w => w.IdPlace == tempid) <= 1)
                        context.Places.Remove(context.Places.FirstOrDefault(w => w.Id == tempid));
                }
            }
            //////////////////////////////////////////////////////////// проверка подсобытия
            if (main.IdSubevent != null)
            {
                if (modal.Subevent != context.Subevents.FirstOrDefault(f => f.Id == main.IdSubevent).Name)
                    if (context.Mains.Count(w => w.IdSubevent == main.IdSubevent) <= 1)
                        context.Subevents.Remove(context.Subevents.FirstOrDefault(w => w.Id == main.IdSubevent));
            }
            if (modal.Subevent != null) //Если поле не пустое
            {
                var Exist = context.Subevents.FirstOrDefault(c => c.Name == modal.Subevent);
                if (Exist == null)
                {
                    context.Subevents.Add(new Subevent() { Name = FirstCharToUpper(modal.Subevent) });
                    context.Mains.Find(main.Id).IdSubeventNavigation = context.Subevents.Local.FirstOrDefault(a => a.Name == modal.Subevent);
                }
                else
                    context.Mains.Find(main.Id).IdSubeventNavigation = Exist;
            }
            else
                main.IdSubevent = null;
            //////////////////////////////////////////////////////////// проверка подтемы
            if (main.IdSubtheme != null)
            {
                if (modal.Subtheme != context.Subthemes.FirstOrDefault(f => f.Id == main.IdSubtheme).Name)
                    if (context.Mains.Count(w => w.IdSubtheme == main.IdSubtheme) <= 1)
                        context.Subthemes.Remove(context.Subthemes.FirstOrDefault(w => w.Id == main.IdSubtheme));
            }
            if (modal.Subtheme != null) //Если поле не пустое
            {
                var Exist = context.Subthemes.FirstOrDefault(c => c.Name == modal.Subtheme);
                if (Exist == null)
                {
                    context.Subthemes.Add(new Subtheme() { Name = FirstCharToUpper(modal.Subtheme) });
                    context.Mains.Find(main.Id).IdSubthemeNavigation = context.Subthemes.Local.FirstOrDefault(a => a.Name == modal.Subtheme);
                }
                else
                    context.Mains.Find(main.Id).IdSubthemeNavigation = Exist;
            }
            else
                main.IdSubtheme = null;
            //////////////////////////////////////////////////////////// проверка темы
            if (main.IdTheme != null)
            {
                if (modal.Theme != context.Themes.FirstOrDefault(f => f.Id == main.IdTheme).Name)
                    if (context.Mains.Where(w => w.IdTheme == main.IdTheme).Count() <= 1)
                        context.Themes.Remove(context.Themes.FirstOrDefault(w => w.Id == main.IdTheme));
            }
            if (modal.Theme != null) //Если поле не пустое
            {
                var Exist = context.Themes.FirstOrDefault(c => c.Name == modal.Theme);
                if (Exist == null)
                {
                    context.Themes.Add(new Theme() { Name = FirstCharToUpper(modal.Theme) });
                    context.Mains.Find(main.Id).IdThemeNavigation = context.Themes.Local.FirstOrDefault(a => a.Name == modal.Theme);
                }
                else
                    context.Mains.Find(main.Id).IdThemeNavigation = Exist;
            }
            else
                main.IdTheme = null;
            /////////////////////////////////////////////////////////// проверка полной даты
            bool Fdate = ((modal.Day != null) && (modal.Month != null) && (modal.Year != null));
            if (Fdate != main.FDate)
                main.FDate = Fdate;
            /////////////////////////////////////////////////////////// установка даты
            if (modal.Day != main.Day)
                main.Day = modal.Day;
            if (modal.Month != main.Month)
                main.Month = modal.Month;
            if (modal.Year != main.Year)
                main.Year = modal.Year;
            ///////////////////////////////////////////////////////// установка типа данных
            if (int.Parse(modal.DtypeId) != main.IdDtype)
                main.IdDtype = int.Parse(modal.DtypeId);
            /////////////////////////////////////////////////////////// установка папки
            if (FirstCharToUpper(modal.Folder) != main.Folder)
                main.Folder = FirstCharToUpper(modal.Folder);
            /////////////////////////////////////////////////////////// установка публичности
            if (modal.NoPublic != main.NoPublic)
                main.NoPublic = modal.NoPublic;
            /////////////////////////////////////////////////////////// Комментарий
            if (modal.Comment != main.Comments)
                main.Comments = modal.Comment;
            /////////////////////////////////////////////////////////// Сохранение изменений
            context.SaveChanges();
        }
        public void Delete(int id)
        {
            if (id > 0)
            {
                Main main = context.Mains.FirstOrDefault(f => f.Id == id);
                if (main != null)
                {
                    Remove(id);
                    if (context.Mains.Count(w => w.IdAuthor == main.IdAuthor) <= 1)
                        context.Authors.Remove(context.Authors.FirstOrDefault(w => w.Id == main.IdAuthor));
                    if (context.Mains.Count(w => w.IdEvent == main.IdEvent) <= 1)
                        context.Events.Remove(context.Events.FirstOrDefault(w => w.Id == main.IdEvent));
                    if (context.Mains.Count(w => w.IdPlace == main.IdPlace) <= 1)
                        context.Places.Remove(context.Places.FirstOrDefault(w => w.Id == main.IdPlace));
                    if (context.Mains.Count(w => w.IdSubevent == main.IdSubevent) <= 1)
                        context.Subevents.Remove(context.Subevents.FirstOrDefault(w => w.Id == main.IdSubevent));
                    if (context.Mains.Count(w => w.IdSubtheme == main.IdSubtheme) <= 1)
                        context.Subthemes.Remove(context.Subthemes.FirstOrDefault(w => w.Id == main.IdSubtheme));
                    if (context.Mains.Where(w => w.IdTheme == main.IdTheme).Count() <= 1)
                        context.Themes.Remove(context.Themes.FirstOrDefault(w => w.Id == main.IdTheme));
                    context.SaveChanges();
                } 
            }
        }
    }
}
