using System;

namespace ElementsLib.Elements.Config.Methods
{
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using Matrixus.Method;

    public class PositionTimesheetMethod : ArticleGeneralMethod, ICloneable
    {
        public static string METHOD_POSITION_TIMESHEET_EXCEPTION_RESULT_NULL_TEXT = "PositionTimesheetMethod(4): Evaluate Results is not implemented!";

        public PositionTimesheetMethod() : base((ConfigRole)ConfigRoleEnum.METHOD_POSITION_TIMESHEET)
        {
        }

        public override string MethodDecorateMessage(string message)
        {
            return string.Format("PositionTimesheet(METHOD_POSITION_TIMESHEET, 4): { 0 }", message);
        }

        public override object Clone()
        {
            PositionTimesheetMethod cloneArticle = (PositionTimesheetMethod)this.MemberwiseClone();

            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
