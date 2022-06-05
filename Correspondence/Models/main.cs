#nullable disable
using System;
using System.Collections.Generic;

namespace Correspondence.Models
{
    public partial class Main
    {
        public int Id { get; set; }
        public bool? FDate { get; set; }
        public int? Day { get; set; }
        public int? Month { get; set; }
        public int? Year { get; set; }
        public string Folder { get; set; }
        public bool NoPublic { get; set; }
        public int? IdAuthor { get; set; }
        public int? IdEvent { get; set; }
        public int? IdSubevent { get; set; }
        public int? IdTheme { get; set; }
        public int? IdSubtheme { get; set; }
        public int IdPlace { get; set; }
        public int? IdDtype { get; set; }
        public string Comments { get; set; }
        public int IdFiles { get; set; }

        public virtual Author IdAuthorNavigation { get; set; }
        public virtual Dtype IdDtypeNavigation { get; set; }
        public virtual Event IdEventNavigation { get; set; }
        public virtual Files IdFilesNavigation { get; set; }
        public virtual Place IdPlaceNavigation { get; set; }
        public virtual Subevent IdSubeventNavigation { get; set; }
        public virtual Subtheme IdSubthemeNavigation { get; set; }
        public virtual Theme IdThemeNavigation { get; set; }
    }
}