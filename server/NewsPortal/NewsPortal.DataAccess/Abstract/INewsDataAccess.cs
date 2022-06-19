using NewsPortal.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.DataAccess.Abstract
{
    public interface INewsDataAccess : IRepository<News>
    {
    }
}
