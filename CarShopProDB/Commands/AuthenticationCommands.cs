using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopProDB.Commands
{
    /// <summary>
    /// Helper class for authentication commands in the CarShopPro application.
    /// </summary>
    public class AuthenticationCommands
    {
        private readonly CarShopProDBContext _context;

        public AuthenticationCommands(CarShopProDBContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Authenticates a user by checking the provided username and password against the database.
        /// </summary>
        /// <param name="username">The username of the user to authenticate.</param>
        /// <param name="password">The password of the user to authenticate.</param>
        /// <returns>True if the user is authenticated; otherwise, false.</returns>
        public bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = _context.Users.Any(u => u.Username == username && u.Password == password);
            return isAuthenticated;
        }
    }
}
