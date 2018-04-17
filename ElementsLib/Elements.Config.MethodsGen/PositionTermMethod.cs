using System;

namespace ElementsLib.Elements.Config.Methods
{
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using Matrixus.Method;

    public class PositionTermMethod : ArticleGeneralMethod, ICloneable
    {
        public static string METHOD_POSITION_TERM_EXCEPTION_RESULT_NULL_TEXT = "PositionTermMethod(2): Evaluate Results is not implemented!";

        public PositionTermMethod() : base((ConfigRole)ConfigRoleEnum.METHOD_POSITION_TERM)
        {
        }

        public override string MethodDecorateMessage(string message)
        {
            return string.Format("PositionTerm(METHOD_POSITION_TERM, 2): { 0 }", message);
        }

        public override object Clone()
        {
            PositionTermMethod cloneArticle = (PositionTermMethod)this.MemberwiseClone();

            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
