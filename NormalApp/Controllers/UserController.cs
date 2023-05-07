using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.Service.Interfaces;

namespace NormalApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser _user;
        public UserController(IUser user)
        {
            _user = user;
        }

        //Get All Users
        [HttpGet]
        [Route("getall")]
        public IActionResult GetAllRecords()
        {
            var response = _user.GettAllRepo();
            return Ok(response);
        }

        //Get Single User
        [HttpGet]
        [Route("getsingle")]
        public IActionResult GetSingleRecord(int id) 
        {
            var response = _user.GetSingleRepo(id);
            return Ok(response);
        }

        //Add User
        [HttpPost("add")]
        public IActionResult AddUser(User user)
        {
            return Ok(_user.AddUserRepo(user));
        }

        //Delete User
        [HttpDelete]
        public IActionResult DeleteUser(int id) 
        {
            return Ok(_user.DeleteUserRepo(id));
        }

        //Update User
        [HttpPut("edit")]
        public IActionResult EditUser(User user)
        {
            return Ok(_user.UpdateUserRepo(user));
        }

    }
}
