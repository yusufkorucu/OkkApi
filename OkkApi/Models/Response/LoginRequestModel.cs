﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OkkApi.Models.Response
{
    public class LoginRequestModel
    {
        public string UserName{ get; set; }
        
        public string Password {get; set;}
    }
    public class LoginResponseModel
    {
        public string UserName { get; set; }

        public string Access_Token { get; set; }
    }
}
