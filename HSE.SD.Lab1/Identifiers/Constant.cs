﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSE.SD.Lab1.Identifiers
{
    public class Constant : Identifier
    {
        public float Value;

        public Constant(string name, string type, string usageType, float value) : base(name, type, usageType)
        {
            Value = value;
        }
    }
}
