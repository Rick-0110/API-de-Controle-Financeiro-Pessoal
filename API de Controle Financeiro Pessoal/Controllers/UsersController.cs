using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;



namespace FinanceControl.Domain.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
           _userRepository = userRepository;

        }

        [HttpGet]
       public async Task<IActionResult> GetAllAsync()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync(User user)
        {
            await _userRepository.AddAsync(user);
            return CreatedAtAction(nameof(GetAllAsync), new { id = user.Id }, user);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

    }
}
