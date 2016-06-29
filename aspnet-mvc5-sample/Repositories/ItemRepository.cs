using aspnet_mvc5_sample.Data;
using aspnet_mvc5_sample.Models;
using aspnet_mvc5_sample.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aspnet_mvc5_sample.Repositories
{
    public class ItemRepository : IItemRepository
    {
        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            using (var context = new AppDbContext())
            {
                return await context.Items.ToListAsync();
            }
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            using (var context = new AppDbContext())
            {
                return await context.Items.FindAsync(id);
            }
        }

        public async Task SaveAsync(Item item)
        {
            using (var context = new AppDbContext())
            {
                context.Items.Add(item);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Item item)
        {
            using (var context = new AppDbContext())
            {
                context.Entry(item).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new AppDbContext())
            {
                var item = await context.Items.FindAsync(id);
                context.Items.Remove(item);
                await context.SaveChangesAsync();
            }
        }
    }
}
