using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopProDB.Tables
{
    /// <summary>
    /// Represents an order entity in the CarShopPro database.
    /// </summary>
    public class Order
    {
        /// <summary>
        /// Gets or sets the unique identifier for the order.
        /// </summary>
        [Key]
        public int OrderId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the customer associated with the order.
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the car associated with the order.
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// Gets or sets the foreign key for the part associated with the order.
        /// </summary>
        public int PartId { get; set; }

        /// <summary>
        /// Gets or sets the date of the order.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the quantity of items in the order.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the customer associated with the order.
        /// </summary>
        public virtual Customer Customer { get; set; }

        /// <summary>
        /// Gets or sets the car associated with the order.
        /// </summary>
        public virtual Car Car { get; set; }

        /// <summary>
        /// Gets or sets the part associated with the order.
        /// </summary>
        public virtual Part Part { get; set; }
    }
}
