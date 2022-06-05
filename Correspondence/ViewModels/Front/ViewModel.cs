using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Correspondence.ViewModels
{
    public class ViewModel
    {
        public FilterModel Filter { get; set; }

        public ModalModel Modal { get; set; }
        public SortModel Sort { get; set; }
        public List<TableModel> Table { get; set; }
        public ViewModel()
        {
            Filter = new FilterModel();
            Modal = new ModalModel();
            Sort = new SortModel();
        }
    }
}
