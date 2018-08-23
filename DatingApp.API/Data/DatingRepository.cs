using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class DatingRepository : IDatingRepository
    {
        private readonly DataContext _context;
        public DatingRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        // Here we dont need to specify that it is a async method because we dont actually write 
        // or do anyhting with the Db, the process is only done on the memory.
        // then when we call the method save. it will do the async task.
        public void Delete<T>(T entity) where T : class
        {
           _context.Remove(entity);
        }
        // because it gets to the Db and Back, we need to specify its a async method so we use.
        // async and await keyword.
        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.Include(p => p.Photos).FirstOrDefaultAsync(u => u.id == id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.Include(p => p.Photos).ToListAsync();

            return users;
        }
        // This is where the add end Delete Method will Async affect the database.
        public  async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}