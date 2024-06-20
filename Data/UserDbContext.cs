using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using UserModel;

namespace Recepty.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext (DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserModel.User> Users { get; set; } = default!;
    }
}
