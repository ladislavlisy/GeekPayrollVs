using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ElementsLib.Module.Common
{
    public static class GeneralFactory<T>
    {
        public static T InstanceFor(Assembly assembly, string namespacePrefix, string className, string clazzName)
        {
            string instanceClass = ClassNameFor(namespacePrefix, className);

            Type instanceType = assembly.GetType(instanceClass);

            if (instanceType == null && clazzName != "")
            {
                instanceClass = ClassNameFor(namespacePrefix, clazzName);

                instanceType = assembly.GetType(instanceClass);
            }

            if (instanceType == null)
            {
                throw new InvalidOperationException("Class does't exist: " + instanceClass);
            }

            T instance = (T)Activator.CreateInstance(instanceType);
            if (instance == null)
            {
                throw new InvalidOperationException("Instance wasn't created: " + instanceClass);
            }
            return instance;
        }

        public static string ClassNameFor(string namespacePrefix, string className)
        {
            string fullClassName = string.Join(".", namespacePrefix, className);

            return fullClassName;
        }
    }
}
