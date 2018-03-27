using System;
using System.Linq;

namespace ElementsLib.ModuleConfig.Json
{
    using Libs;
    using Interfaces;

    public class ArticleConfigJson
    {
        public string Code { get; set; }
        public string Role { get; set; }
        public string[] ResolvePath { get; set; }

        public ArticleConfigJson()
        {
            Code = "";
            Role = "";
            ResolvePath = new string[] { };
        }
    }
}
