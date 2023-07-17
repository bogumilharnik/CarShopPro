using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopProDB.Tables
{
    /// <summary>
    /// Represents a car entity in the CarShopPro database.
    /// </summary>
    public class Car
    {
        /// <summary>
        /// Gets or sets the unique identifier for the car.
        /// </summary>
        public int CarId { get; set; }

        /// <summary>
        /// Gets or sets the brand of the car.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the model of the car.
        /// </summary>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the year of the car.
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// Gets or sets the color of the car.
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// Gets or sets the price of the car.
        /// </summary>
        public decimal Price { get; set; }
    }
}
