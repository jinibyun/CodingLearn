﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DatingApp.WebApiService.Dto
{
    public class UserForLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}