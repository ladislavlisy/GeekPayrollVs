using System;

namespace ElementsLib.Elements
{
    using HeadCode = UInt16;
    using PartCode = UInt16;
    using BodyCode = UInt16;
    using BodySeed = UInt16;
    using BodySort = UInt16;

    using Module.Libs;

    public class ArticleTarget : IComparable<ArticleTarget>, IEquatable<ArticleTarget> 
    {
        public const HeadCode HEAD_CODE_NULL = 0;
        public const PartCode PART_CODE_NULL = 0;

        public const BodySeed BODY_SEED_NULL = 0;
        public const BodySeed BODY_SEED_FIRST = 1;

        public HeadCode Head { get; protected set; }
        public PartCode Part { get; protected set; }
        public BodyCode Code { get; protected set; }
        public BodySeed Seed { get; protected set; }
        public BodySort Sort { get; protected set; }

        public ArticleTarget(HeadCode codeHead, PartCode codePart, BodyCode codeBody, BodySeed seedBody)
        {
            this.Head = codeHead;
            this.Part = codePart;
            this.Code = codeBody;
            this.Seed = seedBody;
        }

        public int CompareTo(ArticleTarget other)
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

        private bool IsGreaterToSame(ArticleTarget other)
        {
            if (this.Head != other.Head)
            {
                return (this.Head > other.Head);
            }
            if (this.Part != other.Part)
            {
                return (this.Part > other.Part);
            }
            if (this.Code != other.Code)
            {
                return (this.Code > other.Code);
            }
            return (this.Seed > other.Seed);
        }

        private bool IsSmallerToSame(ArticleTarget other)
        {
            if (this.Head != other.Head)
            {
                return (this.Head < other.Head);
            }
            if (this.Part != other.Part)
            {
                return (this.Part < other.Part);
            }
            if (this.Code != other.Code)
            {
                return (this.Code < other.Code);
            }
            return (this.Seed < other.Seed);
        }

        private bool IsEqualToSame(ArticleTarget other)
        {
            return (this.Head == other.Head && this.Part == other.Part && this.Code == other.Code && this.Seed == other.Seed);
        }

        public bool IsEqualToHeadPartCode(HeadCode otherHead, PartCode otherPart, BodyCode otherCode)
        {
            return (this.Head == otherHead && this.Part == otherPart && this.Code == otherCode);
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


        public bool Equals(ArticleTarget other)
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

            result += prime * result + (int)this.Part;
            result += prime * result + (int)this.Head;
            result += prime * result + (int)this.Code;
            result += prime * result + (int)this.Seed;

            return result;
        }

        public virtual object Clone()
        {
            ArticleTarget clone = (ArticleTarget)this.MemberwiseClone();
            return clone;
        }

        public override string ToString()
        {
            return string.Format("{0}-{1}-{2}-{3}", this.Head.ToString(), this.Part.ToString(), this.Code.ToString(), this.Seed.ToString());
        }

        public string ToSymbolString<TENUM>() where TENUM : struct, IComparable
        {
            TENUM codeEnum = this.Code.ToEnum<TENUM>();

            return string.Format("{0}-{1}-{2}-{3}", this.Head.ToString(), this.Part.ToString(), codeEnum.ToString(), this.Seed.ToString());
        }
    }
}
