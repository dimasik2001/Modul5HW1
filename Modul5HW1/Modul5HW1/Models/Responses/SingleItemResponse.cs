﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5HW1.Models
{
    public class SingleItemResponse<T>
    {
        public T Data { get; set; }
        public Support Support { get; set; }
    }
}
