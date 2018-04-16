﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Interfaces.Permadom
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;
    using ConfigType = UInt16;
    using SymbolName = String;

    public class ArticleCodeConfigData
    {
        public ConfigCode Code { get; set; }
        public ConfigRole Role { get; set; }
        public ConfigType Type { get; set; }
        public SymbolName Name { get; set; }
        public ConfigCode[] Path { get; set; }

        public ArticleCodeConfigData(ConfigCode _code, ConfigRole _role, ConfigType _type, SymbolName _name, 
            params ConfigCode[] _path)
        {
            Code = _code;
            Role = _role;
            Type = _type;
            Name = _name;
            Path = _path.ToArray();
        }

        public override string ToString()
        {
            return string.Format("{0}, {1}, {2}, \"{3}\", {4}", Code.ToString(), 
                Role.ToString(), Type.ToString(), Name, string.Join(", ", Path));
        }
    }
}
