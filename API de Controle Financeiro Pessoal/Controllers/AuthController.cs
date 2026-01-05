using API_de_Controle_Financeiro_Pessoal.Services;
using FinanceControl.Application.Dtos;
using FinanceControl.Domain.Entities;
using FinanceControl.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API_de_Controle_Financeiro_Pessoal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly TokenService _tokenService;

        public AuthController(IUserRepository userRepository, IPasswordHasher passwordHasher, TokenService tokenService)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        [HttpPost("register")]
       public async Task<IActionResult> Register([FromBody] RegisterUserDto dto)
        {
            var existingUser = await _userRepository.GetByEmailAsync(dto.Email);
            if(existingUser != null)
            {
                return BadRequest("E-mail já está em uso.");
            }

            var passwordHash = _passwordHasher.Hash(dto.Password);

            var user = new User(dto.Name, dto.Email, passwordHash);

            await _userRepository.AddAsync(user);

            return CreatedAtAction(nameof(Register), new { id = user.Id }, null);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var user = await _userRepository.GetByEmailAsync(dto.Email);
            if(user == null || !_passwordHasher.Verify(dto.Password, user.Password))
            {
                return Unauthorized("Credenciais inválidas.");
            }
            var token = _tokenService.GenerateToken(user);
            return Ok(new { Token = token });
        }

    }
}
