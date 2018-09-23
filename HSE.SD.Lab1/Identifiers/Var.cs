using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSE.SD.Lab1.Identifiers
{
    public class Var : Identifier
    {
        public Var(string name, string type, string usageType) : base(name, type, usageType) { }
    }
}
