using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using MA.DomainEntities;
using MA.RepositoryInterfaces;

namespace MA.Repositories.Stores
{
    public class UserReadonlyRepository : IReadonlyRepository<User>
    {
        private readonly IDbConnection _connection;

        public UserReadonlyRepository(IDbConnection connection)
        {
            this._connection = connection;
        }

        public IEnumerable<User> GetAll()
        {
            return _connection.Query<User>("select * from [dbo].[User]").ToList();
        }

        public User Get(Guid id)
        {
            return _connection.Query<User>("select top(1) from [dbo].[User] where ID = @id", new{id}).FirstOrDefault();
        }
    }
}
