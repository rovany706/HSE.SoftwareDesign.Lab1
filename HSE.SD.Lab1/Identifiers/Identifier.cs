﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSE.SD.Lab1.Identifiers
{
    public enum UsageType
    {
        CLASSES,
        CONSTS,
        VARS,
        METHODS
    };

    public enum Type
    {
        int_type,
        float_type,
        bool_type,
        char_type,
        string_type,
        class_type
    };

    public abstract class Identifier
    {
        //Fields
        public string Name;
        public int Hash;
        public Type Type;
        public UsageType UsageType;

        //Class constructor
        protected Identifier(string name, string type, string usageType)
        {
            Name = name;
            Hash = Name.GetHashCode();

            switch (usageType)
            {
                case "class":
                    UsageType = UsageType.CLASSES;
                    break;
                case "const":
                    UsageType = UsageType.CONSTS;
                    break;
                case "var":
                    UsageType = UsageType.VARS;
                    break;
                case "method":
                    UsageType = UsageType.METHODS;
                    break;
            }

            switch (type)
            {
                case "int":
                    Type = Type.int_type;
                    break;
                case "float":
                    Type = Type.float_type;
                    break;
                case "bool":
                    Type = Type.bool_type;
                    break;
                case "char":
                    Type = Type.char_type;
                    break;
                case "string":
                    Type = Type.string_type;
                    break;
                case "class":
                    Type = Type.class_type;
                    break;
            }
        }
    }
}
