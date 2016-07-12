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
        private AppDbContext _context;

        public ItemRepository()
            : this(new AppDbContext())
        {
        }

        public ItemRepository(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetByIdAsync(int id)
        {
            return await _context.Items.Where(x => x.ID == id).SingleAsync();

            //return await _context.Items.FindAsync(id);
        }

        public async Task SaveAsync(Item item)
        {
            _context.Items.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Item item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var item = await _context.Items.FindAsync(id);
            _context.Items.Remove(item);
            await _context.SaveChangesAsync();
        }
    }
}
