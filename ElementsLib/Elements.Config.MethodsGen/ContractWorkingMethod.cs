using System;

namespace ElementsLib.Elements.Config.Methods
{
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using Matrixus.Method;

    public class ContractWorkingMethod : ArticleGeneralMethod, ICloneable
    {
        public static string METHOD_CONTRACT_WORKING_EXCEPTION_RESULT_NULL_TEXT = "ContractWorkingMethod(8): Evaluate Results is not implemented!";

        public ContractWorkingMethod() : base((ConfigRole)ConfigRoleEnum.METHOD_CONTRACT_WORKING)
        {
        }

        public override string MethodDecorateMessage(string message)
        {
            return string.Format("ContractWorking(METHOD_CONTRACT_WORKING, 8): { 0 }", message);
        }

        public override object Clone()
        {
            ContractWorkingMethod cloneArticle = (ContractWorkingMethod)this.MemberwiseClone();

            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
