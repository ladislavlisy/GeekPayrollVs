using System;

namespace ElementsLib.Elements.Config.Methods
{
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using Matrixus.Method;

    public class ContractAbsenceMethod : ArticleGeneralMethod, ICloneable
    {
        public static string METHOD_CONTRACT_ABSENCE_EXCEPTION_RESULT_NULL_TEXT = "ContractAbsenceMethod(9): Evaluate Results is not implemented!";

        public ContractAbsenceMethod() : base((ConfigRole)ConfigRoleEnum.METHOD_CONTRACT_ABSENCE)
        {
        }

        public override string MethodDecorateMessage(string message)
        {
            return string.Format("ContractAbsence(METHOD_CONTRACT_ABSENCE, 9): { 0 }", message);
        }

        public override object Clone()
        {
            ContractAbsenceMethod cloneArticle = (ContractAbsenceMethod)this.MemberwiseClone();

            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
