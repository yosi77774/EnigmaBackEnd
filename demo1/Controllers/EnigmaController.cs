using demo1.models;
using demo1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnigmaController : ControllerBase
    {

        public EnigmaService _enigmaService;

        public EnigmaController(EnigmaService enigmaService)
        {
            _enigmaService = enigmaService;
        }

        [Authorize]
        [HttpPost]
        public String Encrypt([FromForm] EncryptionRequest encryptionRequest)
        {
              StringBuilder status;

              if (encryptionRequest.file == null) 
            {
                   status = _enigmaService.Encryption(encryptionRequest.keys.ToUpper(), encryptionRequest.Text.ToUpper());
            }
            
            else
            {
                StreamReader reader = new StreamReader(encryptionRequest.file.OpenReadStream());
                String file = reader.ReadToEnd();
                reader.Dispose();
                status = _enigmaService.Encryption(encryptionRequest.keys.ToUpper(), file.ToUpper());
            }

             return Convert.ToString(status);

        }

    }
}
