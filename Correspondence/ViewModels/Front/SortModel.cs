using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.ViewModels
{
    public class SortModel
    {
        public List<SelectListItem> Expression { get; set; }
        public List<SelectListItem> Field { get; set; }
        public void InitLists()
        {
            Expression = new List<SelectListItem>(new[]
            {
                (new SelectListItem { Value = "asc", Text = "По возрастанию" }),
                (new SelectListItem { Value = "desc", Text = "По убыванию" })
            });
            Field = new List<SelectListItem>(new[]
            {
                (new SelectListItem { Value = "id", Text = "Код"}),
                (new SelectListItem { Value = "events", Text = "Название книги" }),
                (new SelectListItem { Value = "author", Text = "Автор"}),
                (new SelectListItem { Value = "subevent", Text = "Жанр" }),

                (new SelectListItem { Value = "folder", Text = "Папка" }),
                (new SelectListItem { Value = "place", Text = "Местоположение" }),
                (new SelectListItem { Value = "date", Text = "Дата" }),
                
                (new SelectListItem { Value = "theme", Text = "Тема" }),
                (new SelectListItem { Value = "subtheme", Text = "Подтема" })
                }
            );
        }
        public void Select(string expression, string field)
        {
            UnSelect();
            var _field = Field.FirstOrDefault(w => w.Value == field);
            var exp = Expression.FirstOrDefault(w => w.Value == expression);
            if (exp != null)
                exp.Selected = true;
            if (_field != null)
                _field.Selected = true;
        }
        public void UnSelect()
        {
            var field = Field.FirstOrDefault(w => w.Selected);
            var exp = Expression.FirstOrDefault(w => w.Selected);
            if (exp != null)
                exp.Selected = false;
            if (field != null)
                field.Selected = false;
        }
        public string GetSelectedField()
        {
            return Field.FirstOrDefault(w => w.Selected).Value;
        }
        public string GetSelectedExpression()
        {
            return Expression.FirstOrDefault(w => w.Selected).Value;
        }
    }
}
