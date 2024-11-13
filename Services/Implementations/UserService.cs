using Common.Models;
using Data.Entities;
using Data.Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public void AddUser(UserForCreationDTO userForCreationDTO)
        {
           
        }

        public User? AuthUser(CredentialsDTO credentialsDTO) 
        {
            return _userRepository.AuthUser(credentialsDTO);
        }


    }
}
