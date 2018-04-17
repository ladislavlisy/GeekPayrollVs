using System;

namespace ElementsLib.Elements
{
    using HolderHead = UInt16;
    using HolderPart = UInt16;
    using ConfigCode = UInt16;
    using HolderSeed = UInt16;
    using HolderSort = UInt16;

    using Module.Libs;
    using Module.Interfaces.Elements;

    public class ArticleHolder : IArticleHolder 
    {
        public const HolderHead HEAD_CODE_NULL = 0;
        public const HolderPart PART_CODE_NULL = 0;

        public const HolderSeed BODY_SEED_NULL = 0;
        public const HolderSeed BODY_SEED_FIRST = 1;

        protected HolderHead InternalHead { get; set; }
        protected HolderPart InternalPart { get; set; }
        protected ConfigCode InternalCode { get; set; }
        protected HolderSeed InternalSeed { get; set; }
        protected HolderSort InternalSort { get; set; }

        public HolderHead Head()
        {
            return InternalHead;
        }

        public HolderPart Part()
        {
            return InternalPart;
        }

        public ConfigCode Code()
        {
            return InternalCode;
        }

        public HolderSeed Seed()
        {
            return InternalSeed;
        }

        public ArticleHolder(HolderHead codeHead, HolderPart codePart, ConfigCode codeBody, HolderSeed seedBody)
        {
            this.InternalHead = codeHead;
            this.InternalPart = codePart;
            this.InternalCode = codeBody;
            this.InternalSeed = seedBody;
        }

        public int CompareTo(IArticleHolder other)
        {
            if (IsEqualToSame(other))
            {
                return 0;
            }
            else if (IsGreaterToSame(other))
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }

        private bool IsGreaterToSame(IArticleHolder other)
        {
            if (this.InternalHead != other.Head())
            {
                return (this.InternalHead > other.Head());
            }
            if (this.InternalPart != other.Part())
            {
                return (this.InternalPart > other.Part());
            }
            if (this.InternalCode != other.Code())
            {
                return (this.InternalCode > other.Code());
            }
            return (this.InternalSeed > other.Seed());
        }

        private bool IsSmallerToSame(IArticleHolder other)
        {
            if (this.InternalHead != other.Head())
            {
                return (this.InternalHead < other.Head());
            }
            if (this.InternalPart != other.Part())
            {
                return (this.InternalPart < other.Part());
            }
            if (this.InternalCode != other.Code())
            {
                return (this.InternalCode < other.Code());
            }
            return (this.InternalSeed < other.Seed());
        }

        private bool IsEqualToSame(IArticleHolder other)
        {
            return (this.InternalHead == other.Head() && this.InternalPart == other.Part() && this.InternalCode == other.Code() && this.InternalSeed == other.Seed());
        }
        public bool IsEqualToHeadHolderPart(IArticleHolder other)
        {
            return (this.InternalHead == other.Head() && this.InternalPart == other.Part() && this.InternalCode == other.Code());
        }
        public bool IsEqualToHeadHolderPart(HolderHead otherHead, HolderPart otherPart, ConfigCode otherCode)
        {
            return (this.InternalHead == otherHead && this.InternalPart == otherPart && this.InternalCode == otherCode);
        }

        public static bool operator <(ArticleHolder x, ArticleHolder y)
        {
            return x.IsSmallerToSame(y);
        }

        public static bool operator >(ArticleHolder x, ArticleHolder y)
        {
            return x.IsGreaterToSame(y);
        }

        public static bool operator <=(ArticleHolder x, ArticleHolder y)
        {
            if (x.IsEqualToSame(y))
            {
                return true;
            }
            return x.IsSmallerToSame(y);
        }

        public static bool operator >=(ArticleHolder x, ArticleHolder y)
        {                                                                         
            if (x.IsEqualToSame(y))                               
            {
                return true;
            }
            return x.IsGreaterToSame(y);
        }


        public bool Equals(IArticleHolder other)
        {
            return this.IsEqualToSame(other);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            ArticleHolder other = obj as ArticleHolder;

            return this.IsEqualToSame(other);
        }


        public override int GetHashCode()
        {
            int prime = 31;
            int result = 1;

            result += prime * result + (int)this.InternalPart;
            result += prime * result + (int)this.InternalHead;
            result += prime * result + (int)this.InternalCode;
            result += prime * result + (int)this.InternalSeed;

            return result;
        }

        public virtual object Clone()
        {
            ArticleHolder clone = (ArticleHolder)this.MemberwiseClone();
            return clone;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}-{3}", this.InternalHead.ToString(), this.InternalPart.ToString(), this.InternalCode.ToString(), this.InternalSeed.ToString());
        }

        public string ToSymbolString<TENUM>() where TENUM : struct, IComparable
        {
            TENUM codeEnum = this.InternalCode.ToEnum<TENUM>();

            return string.Format("{0}-{1}-{2}-{3}", this.InternalHead.ToString(), this.InternalPart.ToString(), codeEnum.ToString(), this.InternalSeed.ToString());
        }

    }
}
