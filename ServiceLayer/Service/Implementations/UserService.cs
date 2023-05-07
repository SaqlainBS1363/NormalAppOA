using DomainLayer.Models;
using RepositoryLayer;
using ServiceLayer.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service.Implementations
{
    public class UserService : IUser
    {
        private readonly AppDbContext _appDbContext;

        public UserService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        //Get All Users
        public List<User> GettAllRepo()
        {
            return _appDbContext.users.ToList();
        }

        //Get Single User
        public User GetSingleRepo(int id)
        {
            return _appDbContext.users.Find(id);
            //return _appDbContext.users.Where(u => u.UserId == id).FirstOrDefault();
        }

        //Add User
        public string AddUserRepo(User user)
        {
            try
            {
                _appDbContext.users.Add(user);
                _appDbContext.SaveChanges();
                return "Successfully added the user.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Delete User
        public string DeleteUserRepo(int id)
        {
            try
            {
                User user = _appDbContext.users.Find(id);
                _appDbContext.users.Remove(user);
                _appDbContext.SaveChanges();
                return "Successfully removed the user.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        //Update User
        public string UpdateUserRepo(User user)
        {
            try
            {
                var searchedUser = _appDbContext.users.Find(user.UserId);
                if (searchedUser != null)
                {
                    _appDbContext.users.Update(user);
                    _appDbContext.SaveChanges();

                    return "User updated successfully";
                }
                else
                    return "No user found with this info.";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
