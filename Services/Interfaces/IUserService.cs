using Common.Models;
using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User? GetUserById(int id);
        void AddUser(UserForCreationDTO userForCreationDTO);
        User? AuthUser(CredentialsDTO credentialsDTO);
    }
}
