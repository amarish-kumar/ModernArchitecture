using System;
using MA.DomainEntities;
using MA.RepositoryInterfaces;
using Microsoft.AspNetCore.Http;

namespace MA.Repositories.EF
{
    public class WebContextOptionsRepository : IContextOptionsRepository
    {
        ContextOptions _options;

        public WebContextOptionsRepository(IHttpContextAccessor httpAccessor)
        {
            _options = new ContextOptions
            {
                TenantId = httpAccessor.HttpContext.Request.Host.Host.StartsWith("localhost") ? Guid.Empty : Guid.NewGuid()
            };
        }

        public ContextOptions GetOptions()
        {
            return _options;
        }
    }
}
