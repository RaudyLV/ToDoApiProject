using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApi.Dtos;
using ToDoApi.Dtos.Auth;
using ToDoApi.Interfaces;
using ToDoApi.Models;

namespace ToDoApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IJWTServices _jWTServices;
        public AuthController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IJWTServices jWTServices)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jWTServices = jWTServices;
        }



        [HttpPost("register")]
        public async Task<IActionResult> SignIn([FromBody] RegisterDto request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var newUser = new AppUser
                {
                    FullName = request.FullName,
                    Email = request.Email,
                    UserName = request.Email,
                    EmailConfirmed = true
                };

                var createUser = await _userManager.CreateAsync(newUser, request.Password);
                if(createUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(newUser, "User");
                    if(roleResult.Succeeded)
                    {
                        return Ok
                        (
                          new NewUserDTO
                          {
                            Email = newUser.Email,
                            Token = _jWTServices.CreateToken(newUser)
                          }  
                        );
                    }
                    else
                    {
                        return BadRequest(roleResult.Errors);
                    }
                }
                else
                {
                    return BadRequest(createUser.Errors);
                }
            }
            catch(Exception ex)
            {
                return Problem(detail: ex.Message);
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> LogIn([FromBody] LoginDto request)
        {
         
                if(!ModelState.IsValid)
                    return  BadRequest(ModelState);

                var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == request.Email);
                if(user == null) return Unauthorized("EL usuario no existe.");

                var signInUser = await _signInManager.CheckPasswordSignInAsync(user!, request.Password, false);
                if(!signInUser.Succeeded) return Unauthorized("La contraseña o email son incorrectos");
                
                return Ok
                (
                    new UserLoginDto
                    {
                        Email = user.Email!,
                        Token = _jWTServices.CreateToken(user)
                    }
                );
        }
    }
}