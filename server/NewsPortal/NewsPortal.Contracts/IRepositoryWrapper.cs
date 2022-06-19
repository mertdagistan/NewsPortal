using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Contracts
{
    public interface IRepositoryWrapper
    {
        IUsersRepository Users { get; }
        INewsRepository News{ get; }

        bool Save();
    }
}
