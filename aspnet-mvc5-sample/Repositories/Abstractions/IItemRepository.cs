using aspnet_mvc5_sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_sample.Repositories.Abstractions
{
    public interface IItemRepository
    {
        IEnumerable<Item> GetAll();
        Task<IEnumerable<Item>> GetAllAsync();
        Task<Item> GetByIdAsync(int id);
        Task SaveAsync(Item item);
        Task UpdateAsync(Item item);
        Task DeleteAsync(int id);
    }


}
