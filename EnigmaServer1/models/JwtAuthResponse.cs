﻿using System;

namespace EnigmaServer1.models
{
    [Serializable]
    public class JwtAuthResponse
    {
        public string token { get; set; }
        public string user_name { get; set; }
        public int expires_in { get; set; }
    }
}
