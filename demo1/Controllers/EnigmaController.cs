using demo1.models;
using demo1.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

     /*   [Authorize]
        [HttpPost]
        public String Encrypt(String keys, string Text)
        {

            //String keys = "BBB";
            var status =  _enigmaService.Encryption(keys.ToUpper(), Text.ToUpper());
            return status;

        }*/

        

        [Authorize]
        [HttpPost]
        public String Encrypt(EncryptionRequest encryptionRequest)
        {

            //String keys = "BBB";
            var status = _enigmaService.Encryption(encryptionRequest.keys.ToUpper(), encryptionRequest.Text.ToUpper());
            return Convert.ToString(status);

        }
    }
}
