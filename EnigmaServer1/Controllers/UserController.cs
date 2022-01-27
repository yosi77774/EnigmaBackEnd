using EnigmaServer1.models;
using EnigmaServer1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EnigmaServer1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

       
        //-----------------------treds---------------------------------//
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _userService.GetAsync());
        }

        [HttpGet("{id:length(24)}", Name = "GetClienteAsync")]
        public async Task<IActionResult> GetById(string id)
        {
            var cliente = await _userService.GetByIdAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {

            var status = await _userService.CreateUserAsync(user);
              return Ok(status);

        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, User us)
        {
            var user = _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userService.UpdateAsync(id, us);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteById(string id)
        {
            var user = await _userService.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            await _userService.DeleteByIdAsync(user._id);

            return NoContent();
        }
    }
}
