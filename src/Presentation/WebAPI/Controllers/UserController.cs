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
            var userViewModels = users.Select(UserMapper.MapUserViewModel);
            return Ok(userViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UserInputModel userInputModel)
        {
            var user = UserMapper.MapUser(userInputModel);
            await _userRepository.AddAsync(user);
            return Ok(user);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserInputModel userInputModel)
        {
            var user = await _userRepository.GetByIdAsync(userInputModel.Id.Value);
            if (user == null)
            {
                return NotFound();
            }
            user = UserMapper.MapUser(userInputModel);
            await _userRepository.UpdateAsync(user);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            
            await _userRepository.DeleteAsync(id);
            return Ok();
        }

        #endregion
    }
}
