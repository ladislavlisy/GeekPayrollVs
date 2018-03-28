using System;

namespace ElementsLib.ModuleBucket
{
    using ContractCode = UInt16;
    using PositionCode = UInt16;
    using TargetCode = UInt16;
    using TargetSeed = UInt16;

    using Interfaces;
    using Libs;

    public class ArticleTarget : IComparable<ArticleTarget>, IEquatable<ArticleTarget> 
    {
        public const ContractCode CONTRACT_CODE_NULL = 0;
        public const PositionCode POSITION_CODE_NULL = 0;

        public const TargetSeed SEED_NULL = 0;
        public const TargetSeed SEED_FIRST = 1;

        public ContractCode Contract { get; protected set; }
        public PositionCode Position { get; protected set; }
        public TargetCode Code { get; protected set; }
        public TargetSeed Seed { get; protected set; }

        public ArticleTarget(ContractCode contract, PositionCode position, TargetCode code, TargetSeed seed)
        {
            this.Contract = contract;
            this.Position = position;
            this.Code = code;
            this.Seed = seed;
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
            if (this.Contract != other.Contract)
            {
                return (this.Contract > other.Contract);
            }
            if (this.Position != other.Position)
            {
                return (this.Position > other.Position);
            }
            if (this.Code != other.Code)
            {
                return (this.Code > other.Code);
            }
            return (this.Seed > other.Seed);
        }

        private bool IsSmallerToSame(ArticleTarget other)
        {
            if (this.Contract != other.Contract)
            {
                return (this.Contract < other.Contract);
            }
            if (this.Position != other.Position)
            {
                return (this.Position < other.Position);
            }
            if (this.Code != other.Code)
            {
                return (this.Code < other.Code);
            }
            return (this.Seed < other.Seed);
        }

        private bool IsEqualToSame(ArticleTarget other)
        {
            return (this.Contract == other.Contract && this.Position == other.Position && this.Code == other.Code && this.Seed == other.Seed);
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

            result += prime * result + (int)this.Position;
            result += prime * result + (int)this.Contract;
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
            return string.Format("{0}-{1}-{2}-{3}", this.Contract.ToString(), this.Position.ToString(), this.Code.ToString(), this.Seed.ToString());
        }

        public string SymbolDescription<TENUM>() where TENUM : struct, IComparable
        {
            TENUM typeCode = this.Code.ToEnum<TENUM>();

            return string.Format("{0}-{1}-{2}-{3}", this.Contract.ToString(), this.Position.ToString(), typeCode.ToString(), this.Seed.ToString());
        }
    }
}
