using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopProDB.Commands
{
    public class RemoveByID
    {
        private readonly CarShopProDBContext _context;

        public RemoveByID(CarShopProDBContext context)
        {
            _context = context;
        }

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
