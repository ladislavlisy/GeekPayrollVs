using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Module.Libs
{
    using TargetNode= Interfaces.Elements.IArticleTarget;
    using TargetItem = ResultMonad.Result<Interfaces.Elements.IArticleSource, string>;
    using TargetPair = KeyValuePair<Interfaces.Elements.IArticleTarget, ResultMonad.Result<Interfaces.Elements.IArticleSource, string>>;
    public static class ResultMonadExtensions
    {
        public static string Description(this TargetItem value)
        {
            if (value.IsFailure)
            {
                return string.Format("Error: {0}", value.Error.ToString());
            }
            else
            {
                return value.Value.ToString();
            }
        }
    }
    public static class ResultMonadKeyValueExtensions
    {
        public static string Description(this TargetPair value)
        {
            TargetNode node = value.Key;

            TargetItem item = value.Value;

            return string.Format("{0} {1}", node.ToString(), item.Description());
        }
    }
}
