using Common.Models;
using Data.Entities;
using Data.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository.Implementations
{
    public class UserRepository : IUserRepository
    {
        private CurrencyConverterContext _context;
        public UserRepository(CurrencyConverterContext context)
        {
            _context = context;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }
        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public User? AuthUser(CredentialsDTO credDto)
        {
            return _context.Users.FirstOrDefault(u => u.Username == credDto.Username && u.Password == credDto.Password);
        }

    }
}
