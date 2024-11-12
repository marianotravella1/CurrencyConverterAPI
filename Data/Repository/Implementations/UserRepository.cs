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
        ApplicationContext _context;
        UserRepository(ApplicationContext context)
        {
            _context = context;
        }


    }
}
