using Application.InputModels;
using Application.Interfaces;
using Application.Mapping;
using Microsoft.AspNetCore.Mvc;
using Application.Mapping;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        #region CRUD Operations
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var users = await _userRepository.GetAllAsync();
            var userViewModels = users.Select(UserMapping.GetUserViewModel);
            return Ok(userViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserInputModel userInputModel)
        {
            var user = UserMapping.GetUser(userInputModel);
            await _userRepository.AddAsync(user);
            return Ok();
        }
        



        #endregion
    }
}
