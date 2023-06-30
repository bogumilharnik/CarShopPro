using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShopProDB.Tables;

namespace CarShopProDB.Commands
{
    public class AddToDb
    {
        private readonly CarShopProDBContext _context;

        public AddToDb(CarShopProDBContext context)
        {
            _context = context;
        }

        public void AddPartToDb(Part part)
        {
            if(part is null)
            {
                throw new ArgumentNullException(nameof(part));
            }
            _context.Parts.Add(part);
            _context.SaveChanges();
        }

        public void AddData<T>(T data) where T : class
        {
            if (data is null)
            {
                throw new ArgumentNullException(nameof(data));
            }
    
            _context.Set<T>().Add(data);
            _context.SaveChanges();
        }


    }
}
