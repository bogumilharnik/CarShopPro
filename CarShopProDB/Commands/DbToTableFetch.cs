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
    public class DbToTableFetch
    {
        public DbToTableFetch()
        {
        }
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
