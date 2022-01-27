using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnigmaServer1.models
{
    public class EncryptionRequest
    {

        public string Text { get; set; }

        public string keys { get; set; }

        public IFormFile file { get; set; }
    }
}
