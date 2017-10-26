using System;
using System.Collections.Generic;
using MA.DomainEntities;
using MA.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;

namespace MA.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userServcie;

        public UsersController(IUserService userServcie)
        {
            _userServcie = userServcie;
        }

        // GET api/values
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _userServcie.GetUsers(false);
        }

        // GET api/values/5
        [HttpGet("{id:guid}")]
        public User Get(Guid id)
        {
            return _userServcie.GetUser(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]User user)
        {
            _userServcie.InsertUser(user);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]User user)
        {
            user.ID = id;
            _userServcie.UpdateUser(user);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            _userServcie.DeleteUser(id);
        }
    }
}
