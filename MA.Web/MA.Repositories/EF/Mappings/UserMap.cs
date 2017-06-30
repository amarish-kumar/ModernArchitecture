using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MA.DomainEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MA.Repositories.EF.Mappings
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> entityBuilder)
        {
            entityBuilder.HasKey(t => t.ID);
            entityBuilder.Property(t => t.Username).IsRequired();
            //entityBuilder.Property(t => t.Password).IsRequired();
            //entityBuilder.Property(t => t.Email).IsRequired();
            //entityBuilder.HasOne(t => t.UserProfile).WithOne(u => u.User).HasForeignKey<UserProfile>(x => x.Id);
        }
    }
}
