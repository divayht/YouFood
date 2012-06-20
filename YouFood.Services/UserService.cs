using System.Collections.Generic;
using System.Linq;
using YouFood.Data.Repositories;
using YouFood.Domain.Model;

namespace YouFood.Services
{
    public class UserService
    {
        public UserRepository userRepository;

        public UserService()
        {
            userRepository = new UserRepository();
        }

        public User Get(string username)
        {
            User user = userRepository.Get(x => x.Name == username).SingleOrDefault();
            return user;
        }

        public List<User> GetAll()
        {
            List<User> users = userRepository.GetAll().ToList();
            return users;
        }

        public void AddUser(User user)
        {
            userRepository.Add(user);
        }
    }
}
