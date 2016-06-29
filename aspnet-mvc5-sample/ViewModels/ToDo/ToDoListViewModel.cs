using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_sample.ViewModels.ToDo
{
    public class ToDoListViewModel
    {
        public ToDoListViewModel()
        {
            this.ToDoList = new List<ItemViewModel>();
        }

        public IEnumerable<ItemViewModel> ToDoList { get; set; }
    }
}
