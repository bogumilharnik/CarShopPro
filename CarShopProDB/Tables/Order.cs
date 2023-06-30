using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopProDB.Tables
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int CarId { get; set; }
        public int PartId { get; set; }
        public DateTime OrderDate { get; set; }
        public int Quantity { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Car Car { get; set; }
        public virtual Part Part { get; set; }
    }
}
