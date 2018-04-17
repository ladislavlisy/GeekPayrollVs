using System;

namespace ElementsLib.Elements.Config.Methods
{
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using Matrixus.Method;

    public class PositionScheduleMethod : ArticleGeneralMethod, ICloneable
    {
        public static string METHOD_POSITION_SCHEDULE_EXCEPTION_RESULT_NULL_TEXT = "PositionScheduleMethod(3): Evaluate Results is not implemented!";

        public PositionScheduleMethod() : base((ConfigRole)ConfigRoleEnum.METHOD_POSITION_SCHEDULE)
        {
        }

        public override string MethodDecorateMessage(string message)
        {
            return string.Format("PositionSchedule(METHOD_POSITION_SCHEDULE, 3): { 0 }", message);
        }

        public override object Clone()
        {
            PositionScheduleMethod cloneArticle = (PositionScheduleMethod)this.MemberwiseClone();

            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
