using System;
using System.Collections.Generic;
using System.Linq;

namespace ElementsLib.Matrixus.Config
{
    using ElementsLib.Module.Interfaces.Matrixus;
    public class ArticleReferenceSort<TGang, TCode> : IArticleReferenceSort<TGang, TCode>, ICloneable
    {
        public ArticleReferenceSort()
        {
            this.InternalGang = default(TGang);
            this.InternalPath = new TCode[0];
        }
        public ArticleReferenceSort(TGang _gang, IEnumerable<TCode> _path)
        {
            this.InternalGang = _gang;
            this.InternalPath = _path.ToArray();
        }
        public TGang InternalGang { get; protected set; }
        public IEnumerable<TCode> InternalPath { get; protected set; }

        public TGang Gang()
        {
            return InternalGang;
        }
        public IEnumerable<TCode> Path()
        {
            return InternalPath;
        }

        public bool CodeInPath(TCode _code)
        {
            return InternalPath.Contains(_code);
        }

        public object Clone()
        {
            ArticleReferenceSort<TGang, TCode> cloneMaster = (ArticleReferenceSort<TGang, TCode>)this.MemberwiseClone();
            cloneMaster.InternalGang = this.InternalGang;
            cloneMaster.InternalPath = this.InternalPath.ToArray();

            return cloneMaster;
        }
    }
}
