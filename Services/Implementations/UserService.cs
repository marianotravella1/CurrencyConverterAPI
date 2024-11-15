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
        private readonly ISubscriptionService _subscriptionService;
        public UserService(IUserRepository userRepository, ISubscriptionService subscriptionService)
        {
            _userRepository = userRepository;
            _subscriptionService = subscriptionService;
        }
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }
        public void AddUser(UserForCreationDTO userForCreationDTO)
        {
            try
            {
                if (_userRepository.GetAllUsers().All(u => u.Username != userForCreationDTO.Username))
                {
                    Subscription? sub = _subscriptionService.GetSubscriptionByName(userForCreationDTO.SubscriptionName);

                    if (sub == null)
                    {
                        throw new Exception("The selected subscription cannot be found");
                    }

                    User newUser = new User()
                    {
                        Name = userForCreationDTO.Username,
                        Username = userForCreationDTO.Username,
                        Password = userForCreationDTO.Password,
                        Email = userForCreationDTO.Email,
                        Subscription = sub
                    };

                    _userRepository.AddUser(newUser);
                }
                else throw new Exception($"The username {userForCreationDTO.Username} already exists");
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while creating a user: ", ex);
            }
           
        }

        public User? AuthUser(CredentialsDTO credentialsDTO) 
        {
            return _userRepository.AuthUser(credentialsDTO);
        }

        public User? GetUserById(int id)
        {
            return _userRepository.GetAllUsers().FirstOrDefault(u => u.UserId == id);
        }


    }
}
