using System;

namespace ElementsLib.Elements.Config.Methods
{
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using Matrixus.Method;

    public class PositionWorkingMethod : ArticleGeneralMethod, ICloneable
    {
        public static string METHOD_POSITION_WORKING_EXCEPTION_RESULT_NULL_TEXT = "PositionWorkingMethod(5): Evaluate Results is not implemented!";

        public PositionWorkingMethod() : base((ConfigRole)ConfigRoleEnum.METHOD_POSITION_WORKING)
        {
        }

        public override string MethodDecorateMessage(string message)
        {
            return string.Format("PositionWorking(METHOD_POSITION_WORKING, 5): { 0 }", message);
        }

        public override object Clone()
        {
            PositionWorkingMethod cloneArticle = (PositionWorkingMethod)this.MemberwiseClone();

            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
