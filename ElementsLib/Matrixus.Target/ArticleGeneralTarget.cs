using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Matrixus.Target
{
    using ConfigCode = UInt16;
    using ConfigType = UInt16;
    using ConfigRole = UInt16;

    using Module.Codes;
    using Module.Interfaces.Matrixus;

    public abstract class ArticleGeneralTarget : IArticleTarget, ICloneable
    {
        public abstract string TargetDecorateMessage(string message);
        public ArticleGeneralTarget(ConfigCode code)
        {
            InternalCode = code;
            InternalRole = 0;
            InternalType = 0;
        }

        protected ConfigCode InternalCode { get; set; }
        protected ConfigRole InternalRole { get; set; }
        protected ConfigType InternalType { get; set; }
        protected IList<ConfigRole> InternalPath { get; set; }

        public ConfigCode Code()
        {
            return InternalCode;
        }
        public ConfigRole Role()
        {
            return InternalRole;
        }
        public ConfigType Type()
        {
            return InternalType;
        }
        public ConfigRole[] Path()
        {
            return InternalPath.ToArray();
        }
        public void SetSymbolCode(ConfigCode _code, ConfigType _type, params ConfigCode[] _path)
        {
            InternalCode = _code;

            InternalType = _type;

            InternalPath = _path.ToList();
        }
        public void SetSymbolRole(ConfigRole _role)
        {
            InternalRole = _role;
        }
        public virtual object Clone()
        {
            ArticleGeneralTarget cloneArticle = (ArticleGeneralTarget)this.MemberwiseClone();
            cloneArticle.InternalCode = this.InternalCode;
            cloneArticle.InternalRole = this.InternalRole;
            cloneArticle.InternalPath = this.InternalPath.ToList();

            return cloneArticle;
        }
        public override string ToString()
        {
            return ArticleCodeAdapter.GetSymbol(InternalCode);
        }

    }
}
