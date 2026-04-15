using Microsoft.AspNetCore.Mvc;
using week9_task1.DTOs;
using week9_task1.Models;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly TokenService _tokenService;

    public AuthController(AppDbContext context, TokenService tokenService)
    {
        _context = context;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterDTO dto)
    {
        var user = new UserInfo
        {
            EmailId = dto.EmailId,
            Password = dto.Password,
            Role = dto.Role
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        return Ok("User Registered");
    }

    [HttpPost("login")]
    public IActionResult Login(LoginDTO dto)
    {
        var user = _context.Users
            .FirstOrDefault(u => u.EmailId == dto.EmailId && u.Password == dto.Password);

        if (user == null)
            return Unauthorized();

        var token = _tokenService.GenerateToken(user);

        return Ok(new { token });
    }
}
