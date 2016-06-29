using aspnet_mvc5_sample.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using aspnet_mvc5_sample.ViewModels.ToDo;
using aspnet_mvc5_sample.Framework;
using aspnet_mvc5_sample.Repositories.Abstractions;
using aspnet_mvc5_sample.Repositories;

namespace aspnet_mvc5_sample.Services.ToDo
{
    public class ToDoService : IToDoService
    {
        private readonly ILogger _logger;
        private readonly IItemRepository _repository;

        public ToDoService()
            : this(new Logger(), new ItemRepository())
        { }

        public ToDoService(ILogger logger, IItemRepository repository)
        {
            this._logger = logger;
            this._repository = repository;
        }


        public async Task<ToDoListViewModel> GetAllAsync()
        {
            _logger.Log("...");
            var data = await _repository.GetAllAsync();

            var todoList = new List<ItemViewModel>();
            foreach (var item in data)
            {
                var todo = new ItemViewModel();
                todo.SetFromModel(item);
                todoList.Add(todo);
            }

            var model = new ToDoListViewModel();
            model.ToDoList = todoList;
            return model;
        }

        public async Task<ItemViewModel> GetByIdAsync(int id)
        {
            _logger.Log("...");
            var item = await _repository.GetByIdAsync(id);

            var model = new ItemViewModel();
            model.SetFromModel(item);

            return model;
        }

        public async Task CreateAsync(ItemViewModel item)
        {
            _logger.Log("...");
            await _repository.SaveAsync(item.ConvertToModel());
            
        }

        public async Task EditAsync(ItemViewModel item)
        {
            _logger.Log("...");
            await _repository.UpdateAsync(item.ConvertToModel());
        }

        public async Task DeleteAsync(int id)
        {
            _logger.Log("...");
            await _repository.DeleteAsync(id);
        }

    }
}
