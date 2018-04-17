using System;

namespace ElementsLib.Elements.Config.Methods
{
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using Matrixus.Method;

    public class ContractTimesheetMethod : ArticleGeneralMethod, ICloneable
    {
        public static string METHOD_CONTRACT_TIMESHEET_EXCEPTION_RESULT_NULL_TEXT = "ContractTimesheetMethod(7): Evaluate Results is not implemented!";

        public ContractTimesheetMethod() : base((ConfigRole)ConfigRoleEnum.METHOD_CONTRACT_TIMESHEET)
        {
        }

        public override string MethodDecorateMessage(string message)
        {
            return string.Format("ContractTimesheet(METHOD_CONTRACT_TIMESHEET, 7): { 0 }", message);
        }

        public override object Clone()
        {
            ContractTimesheetMethod cloneArticle = (ContractTimesheetMethod)this.MemberwiseClone();

            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
