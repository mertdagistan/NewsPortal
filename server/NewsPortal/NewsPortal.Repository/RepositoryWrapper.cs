//using NewsPortal.Contracts;
//using NewsPortal.Entities;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace NewsPortal.Repository
//{
//    public  class RepositoryWrapper:IRepositoryWrapper
//    {
//        private readonly RepositoryContext _repoContext;
//        private IUsersRepository _user;
//        private INewsRepository _news;
//        private IRepositoryWrapper _wrapper;

//        public IUsersRepository Users
//        {
//            get
//            {
//                if (_user == null)
//                {
//                    _user = new UsersRepository(_repoContext);
//                }
//                return _user;
//            }
//        }



//        public INewsRepository News
//        {
//            get
//            {
//                if (_news == null)
//                {
//                    _news = new NewsRepository(_repoContext);
//                }
//                return _news;
//            }
//        }

      

//        public RepositoryWrapper(RepositoryContext repositoryContext)
//        {
//            _repoContext = repositoryContext;
//        }

//        public void Save()
//        {
//            _repoContext.SaveChanges();
//        }

//        bool IRepositoryWrapper.Save()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
