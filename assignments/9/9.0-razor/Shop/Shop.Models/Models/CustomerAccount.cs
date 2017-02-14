﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Models.Models
{
    public class CustomerAccount
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set;}

        public Guid Signature { get; set; }
    }
}
