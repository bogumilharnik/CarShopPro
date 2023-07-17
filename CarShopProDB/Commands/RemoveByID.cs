using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopProDB.Commands
{
    /// <summary>
    /// Helper class for removing data from the CarShopPro database by ID.
    /// </summary>
    public class RemoveByID
    {
        private readonly CarShopProDBContext _context;

        public RemoveByID(CarShopProDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Removes data of the specified type from the database using the provided ID.
        /// </summary>
        /// <typeparam name="T">The type of the data to remove. Must be a class type.</typeparam>
        /// <param name="id">The ID of the data to remove.</param>
        /// <returns>True if data with the specified ID is found and removed; otherwise, false.</returns>
        public bool RemoveData<T>(int id) where T : class
        {
            using (var context = new CarShopProDBContext())
            {
                var data = context.Set<T>().Find(id);

                if (data != null)
                {
                    context.Set<T>().Remove(data);
                    context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
