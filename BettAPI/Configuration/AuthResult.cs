﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettAPI.Configuration
{
    public class AuthResult
    {
        public string Token { get; set; }
        public bool Succes { get; set; }

        public List<string> Errors { get; set; }
    }
}
