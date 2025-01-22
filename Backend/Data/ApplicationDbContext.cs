using Common;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Devops.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {
        }

        public DbSet<UserModel> Users { get; set; }
    }
}
