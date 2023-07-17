using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CarShopProDB.Tables;

namespace CarShopProDB.Commands
{
    /// <summary>
    /// Helper class for fetching data from the CarShopPro database.
    /// </summary>
    public class DbToTableFetch
    {
        public DbToTableFetch()
        {
        }

        /// <summary>
        /// Fetches data from the database table of the specified type.
        /// </summary>
        /// <typeparam name="T">The type of the data to fetch. Must be a class type.</typeparam>
        /// <returns>A list of data objects of the specified type from the database.</returns>
        public List<T> FetchData<T>() where T : class
        {
            List<T> dataList = new List<T>();

            using (var context = new CarShopProDBContext())
            {
                dataList = context.Set<T>().ToList();
            }

            return dataList;
        }
    }
}
