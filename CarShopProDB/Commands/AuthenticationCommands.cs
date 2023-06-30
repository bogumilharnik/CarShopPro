using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShopProDB.Commands
{
    public class AuthenticationCommands
    {
        private readonly CarShopProDBContext _context;

        public AuthenticationCommands(CarShopProDBContext context)
        {
            _context = context;
        }

        public bool AuthenticateUser(string username, string password)
        {
            bool isAuthenticated = _context.Users.Any(u => u.Username == username && u.Password == password);
            return isAuthenticated;
        }
    }
}
