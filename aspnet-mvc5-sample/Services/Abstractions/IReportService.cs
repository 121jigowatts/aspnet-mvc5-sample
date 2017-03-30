using aspnet_mvc5_sample.ViewModels.ToDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_sample.Services.Abstractions
{
    public interface IReportService
    {
        byte[] Create(string indexUrl);

        ToDoListViewModel GetAll();
    }
}
