using LearningProject.Data;
using LearningProject.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ApplicationDbContext _context;

    public AuthController(IConfiguration configuration, ApplicationDbContext context)
    {
        _configuration = configuration;
        _context = context;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginDto login)
    {
        // Validate user credentials and get roles (replace with your own logic)
        var (isValid, roles) = ValidateUserAndGetRoles(login);
        if (isValid)
        {
            var token = GenerateJwtToken(login.Username, roles);
            return Ok(new { token });
        }
        return Unauthorized();
    }

    private (bool isValid, List<string> roles) ValidateUserAndGetRoles(LoginDto login)
    {
        // Replace with your own user validation and role retrieval logic
        if (login.Username == "admin" && login.Password == "123")
        {
            return (true, new List<string> { "Admin", "User" });
        }
        else if (login.Username == "user" && login.Password == "userpass")
        {
            return (true, new List<string> { "User" });
        }
        return (false, new List<string>());
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
    {
        //var result = await _authService.RegisterAsync(registerDto);
        // if (result.Succeeded))
        //     return Ok(result.Data);
        // return BadRequest(result.Errors);
        return Ok();
    }
    
    // [HttpPost("create-public-user")]
    // public async Task<ActionResult<User>> CreatePublicUser([FromBody] PublicUserDTO publicUserDto)
    // {
    //     // Create a new User entry (common fields for both internal and public users)
    //     var user = new User
    //     {
    //         Name = publicUserDto.Name,
    //         Email = publicUserDto.Email,
    //         Type = UserType.Public
    //     };

    //     _context.Users.Add(user);
    //     await _context.SaveChangesAsync();

    //     // Now create a PublicUser entry with user-specific fields
    //     var publicUser = new PublicUser
    //     {
    //         Id = user.Id,
    //         RegistrationDate = DateTime.Now,
    //         Address = publicUserDto.Address,
    //         PhoneNumber = publicUserDto.PhoneNumber,
    //         PreferredLanguage = publicUserDto.PreferredLanguage,
    //         IsSubscribedToNewsletter = publicUserDto.IsSubscribedToNewsletter
    //     };

    //     _context.PublicUsers.Add(publicUser);
    //     await _context.SaveChangesAsync();

    //     return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
    // }
    private string GenerateJwtToken(string username, List<string> roles)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, username),
            new Claim(ClaimTypes.Name, username)
        };

        // Add roles to claims
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(180),
            signingCredentials: credentials
        );

        Console.WriteLine($"Token : {new JwtSecurityTokenHandler().WriteToken(token)}");


        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}

