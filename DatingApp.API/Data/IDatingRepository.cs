using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.API.Models;

namespace DatingApp.API.Data
{
    public interface IDatingRepository
    {
        // Add Delete method of type T (the class passed Ex: user or photo...)
        // and Pass this as a parameter of the method;
         void Add<T>(T entity) where T: class;
         void Delete<T>(T entity) where T: class;
         // Check if there is 1 or more save back to db if yes return true all saves have been done
         // else return false there is a probleme saving to the db
         Task<bool> SaveAll();
         Task<IEnumerable<User>> GetUsers();
         Task<User> GetUser(int id);
    }
}