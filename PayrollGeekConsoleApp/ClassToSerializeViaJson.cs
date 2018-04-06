using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollGeekConsoleApp
{
    public interface ITestInterface
    {
        string Guid { get; set; }
    }

    public class TestClassThatImplementsTestInterface1 : ITestInterface
    {
        public string Guid { get; set; }
        public string Something1 { get; set; }
    }

    public class TestClassThatImplementsTestInterface2 : ITestInterface
    {
        public string Guid { get; set; }
        public string Something2 { get; set; }
    }

    public class ClassToSerializeViaJson
    {
        public ClassToSerializeViaJson()
        {
            this.CollectionToSerialize = new List<ITestInterface>();
        }
        public List<ITestInterface> CollectionToSerialize { get; set; }
    }

    public class TypeNameSerializationBinder : ISerializationBinder
    {
        public string TypeFormat { get; private set; }

        public TypeNameSerializationBinder(string typeFormat)
        {
            TypeFormat = typeFormat;
        }

        public void BindToName(Type serializedType, out string assemblyName, out string typeName)
        {
            assemblyName = null;
            typeName = serializedType.Name;
        }

        public Type BindToType(string assemblyName, string typeName)
        {
            var resolvedTypeName = string.Format(TypeFormat, typeName);
            return Type.GetType(resolvedTypeName, true);
        }
    }
    //private static void TestDeserializeList()
    //{
    //    var binder = new TypeNameSerializationBinder("ConsoleApplication.{0}, ConsoleApplication");

    //    var toserialize = new ClassToSerializeViaJson();

    //    toserialize.CollectionToSerialize.Add(
    //        new TestClassThatImplementsTestInterface1()
    //        {
    //            Guid = Guid.NewGuid().ToString(),
    //            Something1 = "Some1"
    //        });
    //    toserialize.CollectionToSerialize.Add(
    //        new TestClassThatImplementsTestInterface2()
    //        {
    //            Guid = Guid.NewGuid().ToString(),
    //            Something2 = "Some2"
    //        });

    //    string json = JsonConvert.SerializeObject(toserialize, Formatting.Indented,
    //        new JsonSerializerSettings
    //        {
    //            TypeNameHandling = TypeNameHandling.None,
    //            SerializationBinder = binder
    //        });
    //    var obj = JsonConvert.DeserializeObject<ClassToSerializeViaJson>(json,
    //        new JsonSerializerSettings
    //        {
    //            TypeNameHandling = TypeNameHandling.All,
    //            SerializationBinder = binder
    //        });

    //    Console.ReadLine();
    //}

    //public IEnumerable<TResult> ReadJson<TResult>(Stream stream)
    //{
    //    var serializer = new JsonSerializer();

    //    using (var reader = new StreamReader(stream))
    //    using (var jsonReader = new JsonTextReader(reader))
    //    {
    //        jsonReader.SupportMultipleContent = true;

    //        while (jsonReader.Read())
    //        {
    //            yield return serializer.Deserialize<TResult>(jsonReader);
    //        }
    //    }
    //}
}
