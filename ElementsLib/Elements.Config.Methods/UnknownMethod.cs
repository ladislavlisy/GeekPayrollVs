using System;

namespace ElementsLib.Elements.Config.Methods
{
    using ConfigRoleEnum = Module.Codes.ArticleRoleCz;
    using ConfigRole = UInt16;

    using Matrixus.Method;

    public class UnknownMethod : ArticleGeneralMethod, ICloneable
    {
        public static string METHOD_UNKNOWN_EXCEPTION_RESULT_NULL_TEXT = "UnknownMethod(0): Evaluate Results is not implemented!";

        public UnknownMethod() : base((ConfigRole)ConfigRoleEnum.METHOD_UNKNOWN)
        {
        }

        public override string MethodDecorateMessage(string message)
        {
            return string.Format("Unknown(METHOD_UNKNOWN, 0): { 0 }", message);
        }

        public override object Clone()
        {
            UnknownMethod cloneArticle = (UnknownMethod)this.MemberwiseClone();

            cloneArticle.InternalRole = this.InternalRole;

            return cloneArticle;
        }

    }
}
