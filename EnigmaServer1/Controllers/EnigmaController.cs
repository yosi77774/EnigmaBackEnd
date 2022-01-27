using EnigmaServer1.models;
using EnigmaServer1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace EnigmaServer1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnigmaController : ControllerBase
    {

        public EnigmaService _enigmaService;

        public  EnigmaController(EnigmaService enigmaService)
        {
            _enigmaService = enigmaService;
        }

        [Authorize]
        [HttpPost]
        public async Task <String> Encrypt([FromForm] EncryptionRequest encryptionRequest)
        {
            String status;
            
            status = await _enigmaService.Encryption(encryptionRequest);
            
            return status;

        }

    }
}
