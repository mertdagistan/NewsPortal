using NewsPortal.DataAccess.Entities;
using NewsPortal.DataAccess.Models;
using NewsPortal.Models.VM.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Business.Abstract
{
    public interface IUsersService
    {
        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        GetManyResult<UserInfoVM> GetUserList();
        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        GetOneResult<UserInfoVM> GetUser(int id);


        GetOneResult<UserInfoVM> CreateUser(UserEditVM user);

        GetOneResult<UserInfoVM> UpdateUser(UserEditVM user);

        bool DeleteUser(int id);
    }
}
