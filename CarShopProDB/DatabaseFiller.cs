using CarShopProDB.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopProDB
{
    public class DatabaseFiller
    {
        private readonly CarShopProDBContext _context;
        private readonly Random _random;


        /// <summary>
        /// Constructor for DatabaseFiller class.
        /// </summary>
        /// <param name="context">The CarShopProDBContext instance.</param>
        public DatabaseFiller(CarShopProDBContext context)
        {
            _context = context;
            _random = new Random();
        }

        /// <summary>
        /// Seed the database with initial data.
        /// </summary>
        public void SeedData()
        {
            if (!_context.Users.Any())
            {
                SeedUsers();
            }

            if (!_context.Cars.Any())
            {
                SeedCars();
            }

            if (!_context.Parts.Any())
            {
                SeedParts();
            }

            if (!_context.Customers.Any())
            {
                SeedCustomers();
            }

            if (!_context.Orders.Any())
            {
                SeedOrders();
            }

            if (!_context.Suppliers.Any())
            {
                SeedSuppliers();
            }
        }

        /// <summary>
        /// Generate random data and populate the Users table.
        /// </summary>
        private void SeedUsers()
        {
            List<User> users = new List<User>
            {
                new User { Username = "admin", Password = "admin123", Role = "Admin" },
                new User { Username = "user1", Password = "user123", Role = "User" },
                new User { Username = "johnDoe", Password = "pass123", Role = "User" },
                new User { Username = "marySmith", Password = "mary123", Role = "User" },
                new User { Username = "janeDoe", Password = "doe456", Role = "User" },
                new User { Username = "alexJohnson", Password = "alex789", Role = "User" },
                new User { Username = "samWilson", Password = "samuelW", Role = "User" },
                new User { Username = "lisaBrown", Password = "lisa1234", Role = "User" },
                new User { Username = "michaelJones", Password = "mike4567", Role = "User" },
                new User { Username = "sarahDavis", Password = "sarah789", Role = "User" },
                new User { Username = "davidLee", Password = "davidL", Role = "User" },
                new User { Username = "emilyTaylor", Password = "emily123", Role = "User" },
                new User { Username = "jasonMiller", Password = "jasonM", Role = "User" },
                new User { Username = "amandaWilson", Password = "amandaW", Role = "User" },
                new User { Username = "benjaminSmith", Password = "benjamin123", Role = "User" },
                new User { Username = "natalieDavis", Password = "natalie789", Role = "User" },
                new User { Username = "peterJohnson", Password = "peter456", Role = "User" },
                new User { Username = "oliviaBrown", Password = "olivia123", Role = "User" },
            };

            _context.Users.AddRange(users);
            _context.SaveChanges();
        }

        /// <summary>
        /// Generate random data and populate the Cars table.
        /// </summary>
        private void SeedCars()
        {
            List<Car> cars = new List<Car>
            {
                new Car { Brand = "Toyota", Model = "Camry", Year = 2021, Color = "Blue", Price = 25000 },
                new Car { Brand = "Honda", Model = "Accord", Year = 2022, Color = "Red", Price = 28000 },
                new Car { Brand = "Ford", Model = "Mustang", Year = 2020, Color = "Yellow", Price = 35000 },
                new Car { Brand = "Toyota", Model = "Camry", Year = 2021, Color = "Blue", Price = 25000 },
                new Car { Brand = "Honda", Model = "Civic", Year = 2022, Color = "Red", Price = 22000 },
                new Car { Brand = "Ford", Model = "Mustang", Year = 2020, Color = "Black", Price = 35000 },
                new Car { Brand = "Chevrolet", Model = "Silverado", Year = 2019, Color = "White", Price = 28000 },
                new Car { Brand = "Nissan", Model = "Altima", Year = 2021, Color = "Gray", Price = 24000 },
                new Car { Brand = "BMW", Model = "X5", Year = 2023, Color = "Silver", Price = 50000 },
                new Car { Brand = "Mercedes-Benz", Model = "C-Class", Year = 2022, Color = "Black", Price = 45000 },
                new Car { Brand = "Audi", Model = "A4", Year = 2021, Color = "White", Price = 42000 },
                new Car { Brand = "Lexus", Model = "RX", Year = 2020, Color = "Blue", Price = 38000 },
                new Car { Brand = "Hyundai", Model = "Elantra", Year = 2023, Color = "Red", Price = 20000 },
                new Car { Brand = "Kia", Model = "Sportage", Year = 2022, Color = "Silver", Price = 26000 },
                new Car { Brand = "Volkswagen", Model = "Golf", Year = 2021, Color = "Gray", Price = 23000 },
                new Car { Brand = "Subaru", Model = "Forester", Year = 2020, Color = "Green", Price = 27000 },
                new Car { Brand = "Tesla", Model = "Model 3", Year = 2023, Color = "White", Price = 55000 },
                new Car { Brand = "Mazda", Model = "CX-5", Year = 2022, Color = "Red", Price = 28000 },
                new Car { Brand = "GMC", Model = "Sierra", Year = 2021, Color = "Black", Price = 32000 },
                new Car { Brand = "Jeep", Model = "Wrangler", Year = 2020, Color = "Yellow", Price = 36000 },
                new Car { Brand = "Chrysler", Model = "300", Year = 2022, Color = "Silver", Price = 30000 },
                new Car { Brand = "Volvo", Model = "XC90", Year = 2023, Color = "Blue", Price = 48000 },
                new Car { Brand = "Acura", Model = "MDX", Year = 2021, Color = "White", Price = 42000 },
                new Car { Brand = "Land Rover", Model = "Range Rover", Year = 2022, Color = "Black", Price = 65000 },
                new Car { Brand = "Jaguar", Model = "F-Type", Year = 2023, Color = "Red", Price = 60000 },
                new Car { Brand = "Porsche", Model = "911", Year = 2021, Color = "Silver", Price = 90000 },
                new Car { Brand = "Ferrari", Model = "488 GTB", Year = 2022, Color = "Yellow", Price = 250000 },
                new Car { Brand = "Lamborghini", Model = "Aventador", Year = 2023, Color = "Orange", Price = 500000 }
            };

            _context.Cars.AddRange(cars);
            _context.SaveChanges();
        }

        /// <summary>
        /// Generate random data and populate the Parts table.
        /// </summary>
        private void SeedParts()
        {
            List<Part> parts = new List<Part>
            {
                new Part { Name = "Engine", Description = "High-performance engine", Price = 5000, Quantity = 10 },
                new Part { Name = "Brake Pads", Description = "Durable brake pads", Price = 100, Quantity = 50 },
                new Part { Name = "Tire", Description = "All-season tire", Price = 150, Quantity = 100 },
                new Part { Name = "Engine", Description = "High-performance engine", Price = 5000, Quantity = 10 },
                new Part { Name = "Brake Pads", Description = "Durable brake pads for enhanced stopping power", Price = 100, Quantity = 50 },
                new Part { Name = "Tire Set", Description = "Premium tires for excellent traction and performance", Price = 800, Quantity = 20 },
                new Part { Name = "Suspension Kit", Description = "Upgraded suspension kit for improved handling", Price = 1200, Quantity = 15 },
                new Part { Name = "Exhaust System", Description = "Performance exhaust system for increased power and sound", Price = 1500, Quantity = 10 },
                new Part { Name = "Headlights", Description = "High-quality headlights for improved visibility", Price = 300, Quantity = 30 },
                new Part { Name = "Air Filter", Description = "Premium air filter for enhanced engine performance", Price = 50, Quantity = 100 },
                new Part { Name = "Spark Plugs", Description = "High-performance spark plugs for efficient combustion", Price = 10, Quantity = 200 },
                new Part { Name = "Radiator", Description = "Efficient radiator for optimal engine cooling", Price = 250, Quantity = 20 },
                new Part { Name = "Battery", Description = "Reliable battery for consistent starting power", Price = 150, Quantity = 30 },
                new Part { Name = "Alternator", Description = "High-output alternator for increased electrical capacity", Price = 200, Quantity = 25 },
                new Part { Name = "Starter Motor", Description = "Durable starter motor for reliable engine starting", Price = 100, Quantity = 30 },
                new Part { Name = "Fuel Pump", Description = "High-performance fuel pump for efficient fuel delivery", Price = 150, Quantity = 20 },
                new Part { Name = "Power Steering Pump", Description = "Efficient power steering pump for smooth steering", Price = 200, Quantity = 15 },
                new Part { Name = "Brake Calipers", Description = "Quality brake calipers for reliable braking performance", Price = 250, Quantity = 20 },
                new Part { Name = "Transmission Kit", Description = "Upgraded transmission kit for improved shifting", Price = 2000, Quantity = 10 },
                new Part { Name = "Catalytic Converter", Description = "Emission control catalytic converter", Price = 500, Quantity = 15 },
                new Part { Name = "Oxygen Sensor", Description = "Precision oxygen sensor for accurate fuel monitoring", Price = 100, Quantity = 50 },
                new Part { Name = "Ignition Coil", Description = "Quality ignition coil for reliable spark generation", Price = 50, Quantity = 30 },
                new Part { Name = "Drive Belt", Description = "Durable drive belt for smooth power transmission", Price = 30, Quantity = 100 },
                new Part { Name = "Water Pump", Description = "Efficient water pump for proper engine cooling", Price = 150, Quantity = 20 },
                new Part { Name = "Gasket Set", Description = "Comprehensive gasket set for engine sealing", Price = 100, Quantity = 25 },
                new Part { Name = "Control Arm", Description = "Sturdy control arm for stable suspension", Price = 150, Quantity = 15 },
                new Part { Name = "Timing Belt", Description = "Reliable timing belt for precise engine timing", Price = 100, Quantity = 20 },
                new Part { Name = "Wheel Bearing", Description = "Quality wheel bearing for smooth wheel rotation", Price = 80, Quantity = 30 }
            };

            _context.Parts.AddRange(parts);
            _context.SaveChanges();
        }

        /// <summary>
        /// Generate random data and populate the Customers table.
        /// </summary>
        private void SeedCustomers()
        {
            List<Customer> customers = new List<Customer>
            {
                new Customer { FirstName = "John", LastName = "Doe", Email = "john@example.com", Phone = "1234567890" },
                new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", Phone = "9876543210" },
                new Customer { FirstName = "John", LastName = "Doe", Email = "john@example.com", Phone = "1234567890" },
                new Customer { FirstName = "Jane", LastName = "Smith", Email = "jane@example.com", Phone = "9876543210" },
                new Customer { FirstName = "Michael", LastName = "Johnson", Email = "michael@example.com", Phone = "4567890123" },
                new Customer { FirstName = "Sarah", LastName = "Williams", Email = "sarah@example.com", Phone = "8901234567" },
                new Customer { FirstName = "David", LastName = "Brown", Email = "david@example.com", Phone = "2345678901" },
                new Customer { FirstName = "Emily", LastName = "Davis", Email = "emily@example.com", Phone = "6789012345" },
                new Customer { FirstName = "Robert", LastName = "Miller", Email = "robert@example.com", Phone = "0123456789" },
                new Customer { FirstName = "Olivia", LastName = "Taylor", Email = "olivia@example.com", Phone = "7890123456" },
                new Customer { FirstName = "William", LastName = "Anderson", Email = "william@example.com", Phone = "3456789012" },
                new Customer { FirstName = "Sophia", LastName = "Thomas", Email = "sophia@example.com", Phone = "9012345678" },
                new Customer { FirstName = "James", LastName = "Jackson", Email = "james@example.com", Phone = "5678901234" },
                new Customer { FirstName = "Ava", LastName = "White", Email = "ava@example.com", Phone = "1234509876" },
                new Customer { FirstName = "Ethan", LastName = "Martin", Email = "ethan@example.com", Phone = "8901234567" },
                new Customer { FirstName = "Mia", LastName = "Thompson", Email = "mia@example.com", Phone = "3456789012" },
                new Customer { FirstName = "Alexander", LastName = "Garcia", Email = "alexander@example.com", Phone = "6789012345" },
                new Customer { FirstName = "Charlotte", LastName = "Lee", Email = "charlotte@example.com", Phone = "0123456789" },
                new Customer { FirstName = "Daniel", LastName = "Harris", Email = "daniel@example.com", Phone = "7890123456" },
                new Customer { FirstName = "Harper", LastName = "Clark", Email = "harper@example.com", Phone = "2345678901" },
                new Customer { FirstName = "Benjamin", LastName = "Lewis", Email = "benjamin@example.com", Phone = "9012345678" },
                new Customer { FirstName = "Amelia", LastName = "Walker", Email = "amelia@example.com", Phone = "5678901234" },
                new Customer { FirstName = "Henry", LastName = "Hall", Email = "henry@example.com", Phone = "0987654321" },
                new Customer { FirstName = "Elizabeth", LastName = "Young", Email = "elizabeth@example.com", Phone = "5432109876" },
                new Customer { FirstName = "Sebastian", LastName = "Allen", Email = "sebastian@example.com", Phone = "8765432322" }
            };

            _context.Customers.AddRange(customers);
            _context.SaveChanges();
        }

        /// <summary>
        /// Generate random data and populate the Orders table.
        /// </summary>
        private void SeedOrders()
        {
            List<Order> orders = new List<Order>();
            List<Car> cars = _context.Cars.ToList();
            List<Part> parts = _context.Parts.ToList();
            List<Customer> customers = _context.Customers.ToList();

            for (int i = 0; i < 10; i++)
            {
                Order order = new Order
                {
                    CarId = GetRandomEntityId(cars),
                    PartId = GetRandomEntityId(parts),
                    CustomerId = GetRandomEntityId(customers),
                    OrderDate = DateTime.Now.AddDays(-i),
                    Quantity = _random.Next(1, 5)
                };

                orders.Add(order);
            }

            _context.Orders.AddRange(orders);
            _context.SaveChanges();
        }

        /// <summary>
        /// Generate random data and populate the Suppliers table.
        /// </summary>
        private void SeedSuppliers()
        {
            List<Supplier> suppliers = new List<Supplier>
            {
                new Supplier { Name = "Supplier A", Address = "123 Main St", Email = "supplierA@example.com", Phone = "1111111111" },
                new Supplier { Name = "Supplier B", Address = "456 Elm St", Email = "supplierB@example.com", Phone = "2222222222" },
                new Supplier { Name = "Supplier B", Address = "456 Elm St", Email = "supplierB@example.com", Phone = "2222222222" },
                new Supplier { Name = "Supplier C", Address = "789 Oak Ave", Email = "supplierC@example.com", Phone = "3333333333" },
                new Supplier { Name = "Supplier D", Address = "123 Maple Ln", Email = "supplierD@example.com", Phone = "4444444444" },
                new Supplier { Name = "Supplier E", Address = "567 Pine Rd", Email = "supplierE@example.com", Phone = "5555555555" },
                new Supplier { Name = "Supplier F", Address = "890 Cedar Blvd", Email = "supplierF@example.com", Phone = "6666666666" },
                new Supplier { Name = "Supplier G", Address = "234 Birch Dr", Email = "supplierG@example.com", Phone = "7777777777" },
                new Supplier { Name = "Supplier H", Address = "567 Spruce Ave", Email = "supplierH@example.com", Phone = "8888888888" },
                new Supplier { Name = "Supplier I", Address = "901 Elm St", Email = "supplierI@example.com", Phone = "9999999999" },
                new Supplier { Name = "Supplier J", Address = "345 Oak Ave", Email = "supplierJ@example.com", Phone = "1111111111" },
                new Supplier { Name = "Supplier K", Address = "678 Maple Ln", Email = "supplierK@example.com", Phone = "2222222222" },
                new Supplier { Name = "Supplier L", Address = "912 Pine Rd", Email = "supplierL@example.com", Phone = "3333333333" },
                new Supplier { Name = "Supplier M", Address = "345 Cedar Blvd", Email = "supplierM@example.com", Phone = "4444444444" },
                new Supplier { Name = "Supplier N", Address = "678 Birch Dr", Email = "supplierN@example.com", Phone = "5555555555" },
                new Supplier { Name = "Supplier O", Address = "901 Spruce Ave", Email = "supplierO@example.com", Phone = "6666666666" },
                new Supplier { Name = "Supplier P", Address = "234 Elm St", Email = "supplierP@example.com", Phone = "7777777777" },
                new Supplier { Name = "Supplier Q", Address = "567 Oak Ave", Email = "supplierQ@example.com", Phone = "8888888888" },
                new Supplier { Name = "Supplier R", Address = "890 Maple Ln", Email = "supplierR@example.com", Phone = "9999999999" },
                new Supplier { Name = "Supplier S", Address = "123 Pine Rd", Email = "supplierS@example.com", Phone = "1111111111" },
                new Supplier { Name = "Supplier T", Address = "456 Cedar Blvd", Email = "supplierT@example.com", Phone = "2222222222" },
                new Supplier { Name = "Supplier U", Address = "789 Birch Dr", Email = "supplierU@example.com", Phone = "3333333333" },
                new Supplier { Name = "Supplier V", Address = "123 Spruce Ave", Email = "supplierV@example.com", Phone = "4444444444" },
                new Supplier { Name = "Supplier W", Address = "456 Elm St", Email = "supplierW@example.com", Phone = "5555555555" },
                new Supplier { Name = "Supplier X", Address = "789 Oak Ave", Email = "supplierX@example.com", Phone = "6666666666" },
                new Supplier { Name = "Supplier Y", Address = "123 Maple Ln", Email = "supplierY@example.com", Phone = "7777777777" },
                new Supplier { Name = "Supplier Z", Address = "456 Pine Rd", Email = "supplierZ@example.com", Phone = "8888888888" }
            };

            _context.Suppliers.AddRange(suppliers);
            _context.SaveChanges();
        }

        /// <summary>
        /// Get a random entity ID from the given list of entities.
        /// </summary>
        /// <typeparam name="T">The type of entity.</typeparam>
        /// <param name="entities">The list of entities.</param>
        /// <returns>A random entity ID.</returns>
        private int GetRandomEntityId<T>(List<T> entities)
        {
            int index = _random.Next(entities.Count);
            dynamic entity = entities[index];
            return entity.GetType().GetProperty(entity.GetType().Name + "Id").GetValue(entity);
        }
    }
}
