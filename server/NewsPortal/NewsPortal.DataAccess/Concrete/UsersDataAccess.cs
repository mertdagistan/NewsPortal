using NewsPortal.DataAccess.Abstract;
using NewsPortal.DataAccess.Entities;
using NewsPortal.DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.DataAccess.Concrete
{
    public class UsersDataAccess : RepositoryBase<Users>, IUsersDataAccess
    {
        private readonly DataContext _context;
        public UsersDataAccess(DataContext context) : base(context) => _context = context;
    }
}
