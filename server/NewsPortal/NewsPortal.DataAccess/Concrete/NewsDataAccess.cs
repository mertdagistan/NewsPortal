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
    public class NewsDataAccess : RepositoryBase<News>, INewsDataAccess
    {
        private readonly DataContext _context;
        public NewsDataAccess(DataContext context) : base(context) => _context = context;
    }
}
