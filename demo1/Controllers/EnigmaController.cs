using demo1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public String Encrypt(String keys, string Text)
        {

            
            var status =  _enigmaService.Encryption(keys, Text.ToUpper());
            return status;

        }
    }
}
