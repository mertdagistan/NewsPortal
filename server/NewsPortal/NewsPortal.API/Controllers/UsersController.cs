using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NewsPortal.Business.Abstract;
using NewsPortal.Models.VM.Users;

namespace NewsPortal.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;

        public UsersController(IUsersService service)
        {
            _service = service;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetUserList();
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _service.GetUser(id);
            return Ok(result);
        }


        [HttpPost]
        public IActionResult Create(UserEditVM user)
        {
            var result = _service.CreateUser(user);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpPut]
        public IActionResult Update(UserEditVM user)
        {
            var result = _service.UpdateUser(user);
            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var result = _service.DeleteUser(id);
            if (result)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
