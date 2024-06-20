using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ReceptModel;

namespace Recepty.Data
{
    public class ReceptDbContext : DbContext
    {
        public ReceptDbContext (DbContextOptions<ReceptDbContext> options)
            : base(options)
        {
        }

        public DbSet<ReceptModel.Recept> Recept { get; set; } = default!;
    }
}
