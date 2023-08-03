using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
            return await Task.Run(() => Ok(_userRepository.GetAllAsync()));
        }




        #endregion
    }
}
