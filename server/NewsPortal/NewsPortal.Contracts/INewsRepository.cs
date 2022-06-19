using NewsPortal.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Contracts
{
    public interface INewsRepository : IRepositoryBase<News>
    {
    }
}
