using System;
namespace HSE.SD.Lab1.Identifiers
{
    public class Method : Identifier
    {
        public LinearList Parameters;

        public Method(string name, string type, string usageType, Tuple<string, ParameterType>[] parameters) 
            : base(name, type, usageType)
        {
            if (parameters == null)
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
