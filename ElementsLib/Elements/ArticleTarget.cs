﻿using System;

namespace ElementsLib.Elements
{
    using HeadCode = UInt16;
    using PartCode = UInt16;
    using BodyCode = UInt16;
    using BodySeed = UInt16;
    using BodySort = UInt16;

    using Module.Libs;
    using Module.Interfaces.Elements;

    public class ArticleTarget : IArticleTarget 
    {
        public const HeadCode HEAD_CODE_NULL = 0;
        public const PartCode PART_CODE_NULL = 0;

        public const BodySeed BODY_SEED_NULL = 0;
        public const BodySeed BODY_SEED_FIRST = 1;

        protected HeadCode InternalHead { get; set; }
        protected PartCode InternalPart { get; set; }
        protected BodyCode InternalCode { get; set; }
        protected BodySeed InternalSeed { get; set; }
        protected BodySort InternalSort { get; set; }

        public HeadCode Head()
        {
            return InternalHead;
        }

        public PartCode Part()
        {
            return InternalPart;
        }

        public BodyCode Code()
        {
            return InternalCode;
        }

        public BodySeed Seed()
        {
            return InternalSeed;
        }

        public ArticleTarget(HeadCode codeHead, PartCode codePart, BodyCode codeBody, BodySeed seedBody)
        {
            this.InternalHead = codeHead;
            this.InternalPart = codePart;
            this.InternalCode = codeBody;
            this.InternalSeed = seedBody;
        }

        public int CompareTo(IArticleTarget other)
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

        private bool IsGreaterToSame(IArticleTarget other)
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

        private bool IsSmallerToSame(IArticleTarget other)
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

        private bool IsEqualToSame(IArticleTarget other)
        {
            return (this.InternalHead == other.Head() && this.InternalPart == other.Part() && this.InternalCode == other.Code() && this.InternalSeed == other.Seed());
        }

        public bool IsEqualToHeadPartCode(HeadCode otherHead, PartCode otherPart, BodyCode otherCode)
        {
            return (this.InternalHead == otherHead && this.InternalPart == otherPart && this.InternalCode == otherCode);
        }

        public static bool operator <(ArticleTarget x, ArticleTarget y)
        {
            return x.IsSmallerToSame(y);
        }

        public static bool operator >(ArticleTarget x, ArticleTarget y)
        {
            return x.IsGreaterToSame(y);
        }

        public static bool operator <=(ArticleTarget x, ArticleTarget y)
        {
            if (x.IsEqualToSame(y))
            {
                return true;
            }
            return x.IsSmallerToSame(y);
        }

        public static bool operator >=(ArticleTarget x, ArticleTarget y)
        {                                                                         
            if (x.IsEqualToSame(y))                               
            {
                return true;
            }
            return x.IsGreaterToSame(y);
        }


        public bool Equals(IArticleTarget other)
        {
            return this.IsEqualToSame(other);
        }

        public override bool Equals(object obj)
        {
            if (obj == this)
                return true;
            if (obj == null || this.GetType() != obj.GetType())
                return false;

            ArticleTarget other = obj as ArticleTarget;

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
            ArticleTarget clone = (ArticleTarget)this.MemberwiseClone();
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
