using System.Threading.Tasks;
using IceBucket.API.Data;
using IceBucket.API.Dtos;
using IceBucket.API.models;
using Microsoft.AspNetCore.Mvc;

namespace IceBucket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _repo;
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;

        }

        [HttpPost("Register")]

        public async Task<IActionResult> Register (UserForRegisterDto userForRegisterDto )
        { //validate request
            userForRegisterDto.Username  = userForRegisterDto.Username.ToLower();

            if(await _repo.UserExists(userForRegisterDto.Username))
              return BadRequest("Username Already Exist");

            var userToCreate = new User
            {
                Username = userForRegisterDto.Username
            };

            var createdUser = await _repo.Register(userToCreate,userForRegisterDto.Password);
            return StatusCode(201);
            
        }

    }
}