using Microsoft.EntityFrameworkCore;
using NewsPortal.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.DataAccess
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Users> Users { get; set; }
        public DbSet<News> News { get; set; }


    }
}
