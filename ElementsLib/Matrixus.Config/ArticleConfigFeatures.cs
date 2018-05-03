using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Matrixus.Config
{
    using ConfigCode = UInt16;
    using ConfigGang = UInt16;
    using ConfigRole = UInt16;
    using ConfigType = UInt16;
    using ConfigBind = UInt16;

    using ElementsLib.Module.Interfaces.Matrixus;

    public class ArticleConfigFeatures : IArticleConfigFeatures
    {
        protected ConfigCode InternalCode { get; set; }
        protected ConfigGang InternalGang { get; set; }
        protected ConfigRole InternalRole { get; set; }
        protected ConfigType InternalType { get; set; }
        protected ConfigBind InternalBind { get; set; }

        public ArticleConfigFeatures()
        {
            InternalCode = 0;

            InternalGang = 0;

            InternalType = 0;

            InternalBind = 0;
        }
        public ArticleConfigFeatures(ConfigCode _code, ConfigGang _gang, ConfigType _type, ConfigBind _bind)
        {
            InternalCode = _code;

            InternalGang = _gang;

            InternalType = _type;

            InternalBind = _bind;
        }
        public ConfigCode Code()
        {
            return InternalCode;
        }
        public ConfigRole Role()
        {
            return InternalRole;
        }
        public ConfigGang Gang()
        {
            return InternalGang;
        }
        public ConfigType Type()
        {
            return InternalType;
        }
        public ConfigBind Bind()
        {
            return InternalBind;
        }
        public void SetSymbolData(ConfigCode _code, ConfigRole _role, ConfigGang _gang, ConfigType _type, ConfigBind _bind)
        {
            InternalCode = _code;

            InternalRole = _role;

            InternalGang = _gang;

            InternalType = _type;
        }
        public void SetSymbolCode(ConfigCode _code)
        {
            InternalCode = _code;
        }
        public void SetSymbolRole(ConfigRole _role)
        {
            InternalRole = _role;
        }
        public virtual object Clone()
        {
            ArticleConfigFeatures cloneMaster = (ArticleConfigFeatures)this.MemberwiseClone();
            cloneMaster.InternalCode = this.InternalCode;
            cloneMaster.InternalGang = this.InternalGang;
            cloneMaster.InternalRole = this.InternalRole;
            cloneMaster.InternalType = this.InternalType;
            cloneMaster.InternalBind = this.InternalBind;

            return cloneMaster;
        }
    }
}
