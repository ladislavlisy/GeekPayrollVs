using System;

namespace ElementsLib.Elements.Config.Methods
{
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using Matrixus.Method;

    public class PositionAbsenceMethod : ArticleGeneralMethod, ICloneable
    {
        public static string METHOD_POSITION_ABSENCE_EXCEPTION_RESULT_NULL_TEXT = "PositionAbsenceMethod(6): Evaluate Results is not implemented!";

        public PositionAbsenceMethod() : base((ConfigRole)ConfigRoleEnum.METHOD_POSITION_ABSENCE)
        {
        }

        public override string MethodDecorateMessage(string message)
        {
            return string.Format("PositionAbsence(METHOD_POSITION_ABSENCE, 6): { 0 }", message);
        }

        public override object Clone()
        {
            PositionAbsenceMethod cloneArticle = (PositionAbsenceMethod)this.MemberwiseClone();

            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
