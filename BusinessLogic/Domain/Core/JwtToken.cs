﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Domain.Core
{
    public class JwtToken
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
    }
}
