using Correspondence.Models;
using Correspondence.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Correspondence.Interfaces
{
    public interface IMainService
    {
        public bool Remove(int? id);
        public void SaveAll();
        public List<TableModel> GetAllRecord();
        public List<TableModel> GetAllRecordWithFilter(FilterModel filter);
        public CorrespContext GetContext();
        public int? ParseIfNotNullable(string text);
        public string FirstCharToUpper(string input);
       
        public void SetData(int? authorID, int DtypeId, int? eventsID, int? subeventID,
                            int? themeID, int? subthemeID, int placeID,
                            int? day, int? month, int? year, string folder,
                            string comment, bool pub, bool fdate);
        public List<SelectListItem> AddDTypesToList();
        public int LastID();
        public Main GetInfoById(int? id);
        public void ConnectGlobalAuthor(string name, int? id);
        public void ConnectLocalAuthor(string name, int? id);
        public void ConnectGlobalEvent(string name, int? id);
        public void ConnectLocalEvent(string name, int? id);
        public void ConnectGlobalPlace(string name, int? id);
        public void ConnectLocalPlace(string name, int? id);
        public void ConnectGlobalSubevent(string name, int? id);
        public void ConnectLocalSubevent(string name, int? id);
        public void ConnectGlobalSubtheme(string name, int? id);
        public void ConnectLocalSubtheme(string name, int? id);
        public void ConnectGlobalTheme(string name, int? id);
        public void ConnectLocalTheme(string name, int? id);
        public int CountMainsWithAuthorId(int? id);
        public int CountMainsWithEventId(int? id);
        public int CountMainsWithPlaceId(int? id);
        public int CountMainsWithSubeventId(int? id);
        public int CountMainsWithSubthemeId(int? id);
        public int CountMainsWithThemeId(int? id);
        public ModalModel ParseToModalModel(Main record);
        public List<TableModel> ParseToTableModel(List<Main> list);
        public List<TableModel> Sorting(List<TableModel> table, string expression, string field);
        public void Edit(ModalModel modal);
        public void Delete(int id);
    }
    
}
