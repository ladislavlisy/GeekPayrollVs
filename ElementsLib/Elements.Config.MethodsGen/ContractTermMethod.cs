using System;

namespace ElementsLib.Elements.Config.Methods
{
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using Matrixus.Method;

    public class ContractTermMethod : ArticleGeneralMethod, ICloneable
    {
        public static string METHOD_CONTRACT_TERM_EXCEPTION_RESULT_NULL_TEXT = "ContractTermMethod(1): Evaluate Results is not implemented!";

        public ContractTermMethod() : base((ConfigRole)ConfigRoleEnum.METHOD_CONTRACT_TERM)
        {
        }

        public override string MethodDecorateMessage(string message)
        {
            return string.Format("ContractTerm(METHOD_CONTRACT_TERM, 1): { 0 }", message);
        }

        public override object Clone()
        {
            ContractTermMethod cloneArticle = (ContractTermMethod)this.MemberwiseClone();

            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
