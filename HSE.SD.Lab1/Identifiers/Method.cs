using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HSE.SD.Lab1;

namespace HSE.SD.Lab1.Identifiers
{
    enum ParameterType
    {
        param_val,
        param_ref,
        param_out
    };

    public class Method : Identifier
    {
        public LinearList Parameters;

        public Method(string name, string type, string usageType, Tuple<string, string>[] parameters) 
            : base(name, type, usageType)
        {
            if (parameters.Length == 0)
                Parameters = null;
            else
            {
                //Initialise list with first parameter
                Parameters = new LinearList(parameters[0]);

                if (parameters.Length > 1)
                    for (int i = 1; i < parameters.Length; i++)
                        Parameters.Add(parameters[i]);
            }
        }
    }
}
