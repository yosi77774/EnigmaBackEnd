using EnigmaServer1.models;
using EnigmaServer1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EnigmaServer1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HackingController : ControllerBase
    {
        public HackingService _hackingService ;

        public HackingController(HackingService hackingService)
        {
            _hackingService = hackingService;
        }

        [Authorize]
        [HttpPost]
        public async Task<String> Hacking([FromForm] HackingRequest hackingRequest)
        {
            String status;
            
            status = await _hackingService.Hacking(hackingRequest);

            return status;

        }

    }
}
