using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopProDB.Tables
{
    /// <summary>
    /// Represents a supplier entity in the CarShopPro database.
    /// </summary>
    public class Supplier
    {
        /// <summary>
        /// Gets or sets the unique identifier for the supplier.
        /// </summary>
        [Key]
        public int SupplierId { get; set; }

        /// <summary>
        /// Gets or sets the name of the supplier.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the address of the supplier.
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the email address of the supplier.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the phone number of the supplier.
        /// </summary>
        public string Phone { get; set; }
    }
}
