﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenDonHang.Models
{
    internal abstract class BaseCustomSerializable
    {
        public BaseCustomSerializable() { }
        public BaseCustomSerializable(string json) { }

        public abstract string toJson();
    }
}
