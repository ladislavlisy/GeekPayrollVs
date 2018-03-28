﻿using System;
using System.Linq;

namespace ElementsLib.ModuleConfig.Json
{
    using Libs;
    using Interfaces;

    public class ArticleConfigNameJson
    {
        public string Code { get; set; }
        public string Role { get; set; }
        public string[] ResolvePath { get; set; }

        public ArticleConfigNameJson()
        {
            Code = "";
            Role = "";
            ResolvePath = new string[] { };
        }
    }
    public class ArticleConfigNumbJson
    {
        public string Code { get; set; }
        public string Role { get; set; }
        public string[] ResolvePath { get; set; }

        public ArticleConfigNumbJson()
        {
            Code = "";
            Role = "";
            ResolvePath = new string[] { };
        }
    }
}
