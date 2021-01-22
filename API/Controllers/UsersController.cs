using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entitites;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
     [Authorize]
     public class UsersController : BaseApiController
     {
          private readonly IUserRepository _userRepository;

          public UsersController(IUserRepository userRepository)
          {
               _userRepository = userRepository;
          }
          [HttpGet]
          public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
          {
               var users = await _userRepository.GetUsersAsync();
               return Ok(users);
          }

          [HttpGet("{username}")]
          public async Task<ActionResult<AppUser>> GetUsers(string username)
          {
               return await  _userRepository.GetUserByUsernameAsync(username);
          }
     }
}