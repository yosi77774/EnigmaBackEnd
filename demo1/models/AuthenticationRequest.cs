using System;

namespace demo1.models
{
    [Serializable]
    public class AuthenticationRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
