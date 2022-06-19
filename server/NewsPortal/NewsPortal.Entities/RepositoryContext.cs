using Microsoft.EntityFrameworkCore;
using NewsPortal.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Entities
{
    public class RepositoryContext:DbContext
    {
        public RepositoryContext(DbContextOptions options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<News> News { get; set; }


    }
}
