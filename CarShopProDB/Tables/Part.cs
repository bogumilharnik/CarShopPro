using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopProDB.Tables
{
    /// <summary>
    /// Represents a part entity in the CarShopPro database.
    /// </summary>
    public class Part
    {
        /// <summary>
        /// Gets or sets the unique identifier for the part.
        /// </summary>
        public int PartId { get; set; }

        /// <summary>
        /// Gets or sets the name of the part.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the part.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the part.
        /// </summary>
        public decimal Price { get; set; }

        /// <summary>
        /// Gets or sets the quantity of the part in stock.
        /// </summary>
        public int Quantity { get; set; }
    }
}
