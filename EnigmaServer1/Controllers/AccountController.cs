using EnigmaServer1.Auth;
using EnigmaServer1.models;
using EnigmaServer1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EnigmaServer1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        public UserService _userService;

        public AccountController(UserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public async Task <IActionResult> Login(AuthenticationRequest authenticationRequest)
        {
            var jwtAuthenticationManager = new JwtAuthenticationManager();
            var status = await _userService.GetByUserPasswordAsync(authenticationRequest.UserName, authenticationRequest.Password);
            if (status) {
                var authResult =  jwtAuthenticationManager.Authenticate(authenticationRequest.UserName, authenticationRequest.Password);
                return Ok(authResult);
            }
                
            else
                 return Ok(status);

        }
    }
}
