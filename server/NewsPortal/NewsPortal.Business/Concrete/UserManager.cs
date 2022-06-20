using NewsPortal.Business.Abstract;
using NewsPortal.DataAccess.Abstract;
using NewsPortal.DataAccess.Entities;
using NewsPortal.DataAccess.Enum;
using NewsPortal.DataAccess.Models;
using NewsPortal.Models.VM.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsPortal.Business.Concrete
{
    public class UserManager : IUsersService
    {
        private IUsersDataAccess _userDataAccess;

        public UserManager(IUsersDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public GetOneResult<UserInfoVM> CreateUser(UserEditVM user)
        {
            var userEntity = new Users
            {
                FullName = user.FullName,
                Password = user.Password,
                Role = (Role)Enum.Parse(typeof(Role), user.Role),
                UserName = user.UserName
            };

            var result = _userDataAccess.InsertOne(userEntity);
            if (result.Success)
            {
                return new GetOneResult<UserInfoVM>
                {
                    Success = true,
                    Message = "User created successfully",
                    Entity = new UserInfoVM
                    {
                        ID = userEntity.ID,
                        FullName = user.FullName,
                        Role = user.Role.ToString(),
                        UserName = user.UserName
                    }
                };
            }
            else
            {
                return new GetOneResult<UserInfoVM>
                {
                    Success = false,
                    Message = "User creation failed",
                    Entity = null
                };
            }
        }

        public bool DeleteUser(int id) => _userDataAccess.DeleteById(id);

        /// <summary>
        /// Get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public GetOneResult<UserInfoVM> GetUser(int id)
        {
            var result = new GetOneResult<UserInfoVM>();

            try
            {
                // Get user from db by id
                var users = _userDataAccess.GetById(id);

                // If user is not found
                if (users == null)
                {
                    result.Message = "User not found";
                    result.Success = false;
                    return result;
                }

                // If user is found
                result.Entity = new UserInfoVM
                {
                    ID = users.Entity.ID,
                    FullName = users.Entity.FullName,
                    UserName = users.Entity.UserName,
                    Role = ((Role)users.Entity.Role).ToString()
                };
            }
            // If something went wrong
            catch (Exception ex)
            {
                result.Entity = null;
                result.Success = false;
                result.Message = ex.Message;
            }

            return result;
        }

        /// <summary>
        /// Get all users
        /// </summary>
        /// <returns></returns>
        public GetManyResult<UserInfoVM> GetUserList()
        {
            var result = new GetManyResult<UserInfoVM>();

            try
            {
                // Get user list from db
                var users = _userDataAccess.GetAll();

                // If user list is not found
                if (users == null)
                {
                    result.Message = "User list not found";
                    result.Success = false;
                    return result;
                }

                // If user list is found
                result.Result = users.Result.Select(x => new UserInfoVM
                {
                    ID = x.ID,
                    FullName = x.FullName,
                    UserName = x.UserName,
                    Role = ((Role)x.Role).ToString()
                });

            }
            // If something went wrong
            catch (Exception ex)
            {
                result.Result = null;
                result.Success = false;
            }

            return result;
        }

        public GetOneResult<UserInfoVM> UpdateUser(UserEditVM user)
        {
            var userEntity = new Users
            {
                ID = user.ID,
                FullName = user.FullName,
                Password = user.Password,
                Role = (Role)Enum.Parse(typeof(Role), user.Role),
                UserName = user.UserName
            };

            var result = _userDataAccess.UpdateOne(userEntity);
            if (result.Success)
            {
                return new GetOneResult<UserInfoVM>
                {
                    Success = true,
                    Message = "User update successfully",
                    Entity = new UserInfoVM
                    {
                        ID = user.ID,
                        FullName = user.FullName,
                        Role = user.Role.ToString(),
                        UserName = user.UserName
                    }
                };
            }
            else
            {
                return new GetOneResult<UserInfoVM>
                {
                    Success = false,
                    Message = "User update failed",
                    Entity = null
                };
            }
        }
    }
}
