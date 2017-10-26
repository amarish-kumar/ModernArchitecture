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
        private readonly IReadonlyRepository<User> _readonlyUserRepo;
        private readonly IDataContext _dataContext;
        private readonly ILoggerService _logger;

        public UserService(IUserRepository userRepository, IReadonlyRepository<User> readonlyUserRepo, IDataContext context, ILoggerService logger)
        {
            _userRepository = userRepository;
            _dataContext = context;
            _logger = logger;
            _readonlyUserRepo = readonlyUserRepo;
        }

        public IEnumerable<User> GetUsers(bool onlyActive = false)
        {
            _logger.LogInfo("Helo");
            _logger.LogError("Hellll nnnno");
            return onlyActive ? _userRepository.GetActiveUsers() : _readonlyUserRepo.GetAll();
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
