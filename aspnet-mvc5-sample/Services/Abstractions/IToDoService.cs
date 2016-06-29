using aspnet_mvc5_sample.ViewModels.ToDo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_sample.Services.Abstractions
{
    public interface IToDoService
    {
        Task<ToDoListViewModel> GetAllAsync();
        Task<ItemViewModel> GetByIdAsync(int id);
        Task CreateAsync(ItemViewModel item);
        Task EditAsync(ItemViewModel item);
        Task DeleteAsync(int id);
    }
}
