using System.Threading.Tasks;
using DataApp.API.Data;
using DataApp.API.Dto;
using DataApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataApp.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            this._repo = repo;

        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(UserForRegisterDto userForRegisterDto)
        {
          
            userForRegisterDto.Username=userForRegisterDto.Username.ToLower();
            if(await _repo.UserExists(userForRegisterDto.Username))
            {
                return BadRequest("User already exists");
            }

            var userToCreate =new User
            {
                Username=userForRegisterDto.Username
            };

            var createdUser=_repo.Register(userToCreate,userForRegisterDto.Password);

            return StatusCode(201);
        }
    }
}