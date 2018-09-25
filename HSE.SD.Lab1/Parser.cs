using System;
using System.Text.RegularExpressions;
using HSE.SD.Lab1.Identifiers;

namespace HSE.SD.Lab1
{
    public static class Parser
    {
        private static string VarRegexPattern = @"^(?<type>\w+)\s(?<name>\w+);$";
        private static string ConstRegexPattern = @"^const\s(?<type>\w+)\s(?<name>\w+)\s=\s(?<value>[a-zA-Z0-9\.'""]+);$";
        private static string ClassRegexPattern = @"^class\s(?<name>\w+);$";
        private static string MethodRegexPattern = @"^(?<type>\w+)\s(?<name>\w+)\((?<params>.*)\);$";
        private static string MethodParamsRegexPattern = @"((?<paramType>\w+)\s)?(?<type>\w+)\s\w+";

        public static Node Parse(string[] lines)
        {
            Node root = null;
            foreach (string line in lines)
            {
                //Method parse
                if (Regex.IsMatch(line, MethodRegexPattern))
                {
                    Method method;
                    Regex regex = new Regex(MethodRegexPattern);
                    Match match = regex.Match(line);

                    string name = match.Groups["name"].Value;
                    string type = match.Groups["type"].Value;

                    //If no parameters
                    if (match.Groups["params"].Value == String.Empty)
                    {
                        method = new Method(name, type, "method", null);
                        root = Node.Add(root, method);
                        continue;
                    }

                    //Parse parameters
                    string[] parameters = match.Groups["params"].Value.Split(',');
                    regex = new Regex(MethodParamsRegexPattern);

                    //Create array of parameters
                    Tuple<string, ParameterType>[] parametersArray = new Tuple<string, ParameterType>[parameters.Length];
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        Match parameterMatch = regex.Match(parameters[i].Trim());
                        string parameterType = parameterMatch.Groups["type"].Value;

                        //Set usage type
                        ParameterType parameterUsageType = ParameterType.param_val;

                        if (parameterMatch.Groups["paramType"].Value != String.Empty)
                            switch (parameterMatch.Groups["paramType"].Value)
                            {
                                case "ref":
                                    parameterUsageType = ParameterType.param_ref;
                                    break;
                                case "out":
                                    parameterUsageType = ParameterType.param_out;
                                    break;
                            }


                        Tuple<string, ParameterType> parameter = new Tuple<string, ParameterType>(parameterType, parameterUsageType);
                        parametersArray[i] = parameter;
                    }

                    method = new Method(name, type, "method", parametersArray);
                    root = Node.Add(root, method);
                }
                //Const parse
                else if (Regex.IsMatch(line, ConstRegexPattern))
                {
                    Regex regex = new Regex(ConstRegexPattern);
                    Match match = regex.Match(line);

                    string name = match.Groups["name"].Value;
                    string type = match.Groups["type"].Value;

                    object value;
                    if (type == "float")
                        value = float.Parse(match.Groups["value"].Value.Replace('.', ','));
                    else if (type == "int")
                        value = int.Parse(match.Groups["value"].Value);
                    else if (type == "string")
                        value = match.Groups["value"].Value.Replace(@"""", string.Empty);
                    else if (type == "bool")
                    {
                        if (match.Groups["value"].Value == "false")
                            value = false;
                        else
                            value = true;
                    }
                    else 
                        //char
                        // "   c   "
                        //[0] [1] [2]
                        value = match.Groups["value"].Value[1];

                    Constant constant = new Constant(name, type, "const", value);
                    root = Node.Add(root, constant);
                }
                //Class parse
                else if (Regex.IsMatch(line, ClassRegexPattern))
                {
                    Regex regex = new Regex(ClassRegexPattern);
                    Match match = regex.Match(line);

                    string name = match.Groups["name"].Value;

                    Class classId = new Class(name, "class", "class");
                    root = Node.Add(root, classId);
                }
                //Var parse
                else if (Regex.IsMatch(line, VarRegexPattern))
                {
                    Regex regex = new Regex(VarRegexPattern);
                    Match match = regex.Match(line);

                    string name = match.Groups["name"].Value;
                    string type = match.Groups["type"].Value;

                    Var varId = new Var(name, type, "var");
                    root = Node.Add(root, varId);
                }
            }

            return root;
        }
    }
}
