using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Matrixus.Method
{
    using ConfigRole = UInt16;

    using Module.Codes;
    using Module.Interfaces.Matrixus;

    public abstract class ArticleGeneralMethod : IArticleMethod, ICloneable
    {
        public abstract string MethodDecorateMessage(string message);
        public ArticleGeneralMethod(ConfigRole role)
        {
            InternalRole = role;
        }

        protected ConfigRole InternalRole { get; set; }
        protected IList<ConfigRole> InternalPath { get; set; }

        public ConfigRole Role()
        {
            return InternalRole;
        }

        public ConfigRole[] Path()
        {
            return InternalPath.ToArray();
        }
        public void SetSymbolRole(ConfigRole _role, params ConfigRole[] _path)
        {
            InternalRole = _role;

            InternalPath = _path.ToList();
        }
        public virtual object Clone()
        {
            ArticleGeneralMethod cloneArticle = (ArticleGeneralMethod)this.MemberwiseClone();
            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }
        public override string ToString()
        {
            return ArticleRoleAdapter.GetSymbol(InternalRole);
        }

    }
}
