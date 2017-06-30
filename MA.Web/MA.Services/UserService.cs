using System;
using System.Collections.Generic;
using MA.DomainEntities;
using MA.RepositoryInterfaces;
using MA.ServiceInterfaces;

namespace MA.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IDataContext _dataContext;

        public UserService(IUserRepository userRepository, IDataContext context)
        {
            _userRepository = userRepository;
            _dataContext = context;
        }

        public IEnumerable<User> GetUsers(bool onlyActive = false)
        {
            return onlyActive ? _userRepository.GetActiveUsers() : _userRepository.GetAll();
        }

        public User GetUser(Guid id)
        {
            return _userRepository.Get(id);
        }

        public void InsertUser(User user)
        {
            _userRepository.Insert(user);
            _dataContext.SaveChanges();
        }
        public void UpdateUser(User user)
        {
            _userRepository.Update(user);
            _dataContext.SaveChanges();
        }

        public void DeleteUser(Guid id)
        {
            User user = GetUser(id);
            _userRepository.Delete(user);
            _dataContext.SaveChanges();
        }
    }
}
