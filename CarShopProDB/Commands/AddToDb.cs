using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarShopProDB.Tables;

namespace CarShopProDB.Commands
{
    /// <summary>
    /// Helper class to add data to the CarShopPro database.
    /// </summary>
    public class AddToDb
    {
        private readonly CarShopProDBContext _context;

        public AddToDb(CarShopProDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Adds a part to the database.
        /// </summary>
        /// <param name="part">The part to be added.</param>
        /// <exception cref="ArgumentNullException">Thrown if the provided part is null.</exception>
        public void AddPartToDb(Part part)
        {
            if(part is null)
            {
                throw new ArgumentNullException(nameof(part));
            }
            _context.Parts.Add(part);
            _context.SaveChanges();
        }

        /// <summary>
        /// Adds data of the specified type to the database.
        /// </summary>
        /// <typeparam name="T">The type of data to be added.</typeparam>
        /// <param name="data">The data to be added.</param>
        /// <exception cref="ArgumentNullException">Thrown if the provided data is null.</exception>
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
