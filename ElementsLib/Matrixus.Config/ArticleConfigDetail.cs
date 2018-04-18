using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Matrixus.Config
{
    using ConfigCode = UInt16;
    using ConfigRole = UInt16;
    using ConfigType = UInt16;
    using ConfigName = String;
    using ConfigStub = Module.Interfaces.Elements.IArticleSource;

    using Module.Interfaces.Matrixus;
    using Module.Interfaces.Elements;

    public class ArticleConfigDetail : IArticleConfigDetail
    {
        protected ConfigCode InternalCode { get; set; }
        protected ConfigRole InternalRole { get; set; }
        protected ConfigType InternalType { get; set; }
        protected ConfigName InternalName { get; set; }
        protected IList<ConfigCode> InternalPath { get; set; }
        protected ConfigStub InternalStub { get; set; }

        public ArticleConfigDetail(ConfigCode _code, ConfigName _name, ConfigType _type, params ConfigCode[] _path)
        {
            InternalCode = _code;

            InternalName = _name;

            InternalType = _type;

            InternalPath = _path.ToList();
        }
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
        public ConfigName Name()
        {
            return InternalName;
        }
        public ConfigCode[] Path()
        {
            return InternalPath.ToArray();
        }
        public ConfigStub Stub()
        {
            return InternalStub;
        }

        public void SetSymbolCode(ConfigCode _code, ConfigName _name, ConfigType _type, params ConfigCode[] _path)
        {
            InternalCode = _code;

            InternalName = _name;

            InternalType = _type;

            InternalPath = _path.ToList();
        }
        public void SetSymbolRole(ConfigRole _role, ConfigStub _stub)
        {
            InternalRole = _role;

            InternalStub = _stub;
        }
        public virtual object Clone()
        {
            ArticleConfigDetail cloneMaster = (ArticleConfigDetail)this.MemberwiseClone();
            cloneMaster.InternalCode = this.InternalCode;
            cloneMaster.InternalRole = this.InternalRole;
            cloneMaster.InternalType = this.InternalType;
            cloneMaster.InternalName = this.InternalName;
            cloneMaster.InternalPath = this.InternalPath.ToList();
            cloneMaster.InternalStub = (ConfigStub)this.InternalStub.Clone();

            return cloneMaster;
        }
        public override string ToString()
        {
            return InternalName;
        }
    }
}
