using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ElementsLib.Common
{
    public class GeneralFactory<T>
    {
        public static T InstanceFor(Assembly assembly, string namespacePrefix, string className)
        {
            string statuteClass = ClassNameFor(namespacePrefix, className);

            Type statuteType = assembly.GetType(statuteClass);

            if (statuteType == null)
            {
                throw new InvalidOperationException("Class does't exist: " + statuteClass);
            }
            T statuteInstance = (T)Activator.CreateInstance(statuteType);
            if (statuteInstance == null)
            {
                throw new InvalidOperationException("Instance wasn't created: " + statuteClass);
            }
            return statuteInstance;
        }

        public static string ClassNameFor(string namespacePrefix, string className)
        {
            string fullClassName = string.Join(".", new string[] { namespacePrefix, className });

            return fullClassName;
        }
    }
}
