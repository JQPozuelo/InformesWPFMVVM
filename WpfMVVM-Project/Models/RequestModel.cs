﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMVVM_Project.Models
{
    public class RequestModel
    {
        public string route { get; set; }
        public string method { get; set; }
        public object data { get; set; }
    }
}
