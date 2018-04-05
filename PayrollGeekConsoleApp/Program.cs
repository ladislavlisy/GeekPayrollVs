using System;
using System.Collections.Generic;
using ElementsLib.Matrixus.Config;
using ElementsLib.Module.Json;
using ElementsLib.Elements.Config;
using System.Reflection;
using ElementsLib;
using ElementsLib.Module.Interfaces.Elements;
using ElementsLib.Elements.Config.Source;
using ElementsLib.Elements;
using ElementsLib.Legalist.Constants;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using ElementsLib.Elements.Config.Articles;
using Newtonsoft.Json.Serialization;

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
    class Program
    {
        static void Main(string[] args)
        {
            string configFolder = ConfigFilesFolder();

            TestDeserializeList();
            //LoadSourceJson(configFolder);
        }
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

        private static void TestDeserializeList()
        {
            var binder = new TypeNameSerializationBinder("ConsoleApplication.{0}, ConsoleApplication");

            var toserialize = new ClassToSerializeViaJson();

            toserialize.CollectionToSerialize.Add(
                new TestClassThatImplementsTestInterface1()
                {
                    Guid = Guid.NewGuid().ToString(),
                    Something1 = "Some1"
                });
            toserialize.CollectionToSerialize.Add(
                new TestClassThatImplementsTestInterface2()
                {
                    Guid = Guid.NewGuid().ToString(),
                    Something2 = "Some2"
                });

            string json = JsonConvert.SerializeObject(toserialize, Formatting.Indented,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.None,
                    SerializationBinder = binder
                });
            var obj = JsonConvert.DeserializeObject<ClassToSerializeViaJson>(json,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    SerializationBinder = binder
                });

            Console.ReadLine();
        }
        private static void CreatePayrollData()
        {
            ArticleSourceCollection payrollSource = new ArticleSourceCollection();

            Assembly configAssembly = typeof(ElementsModule).Assembly;

            IArticleSourceFactory configFactory = new ArticleSourceFactory();

            payrollSource.InitConfigModel(configAssembly, configFactory);

            var payrollData = new ArticleBucket(payrollSource);

            DateTime? TestDateFrom = new DateTime(2010, 1, 1);
            DateTime? TestDateStop = null;
            var TestEmployeeTerm = WorkEmployTerms.WORKTERM_EMPLOYMENT_1;

            var contractValues = new ContractTermSource(TestDateFrom, TestDateStop, TestEmployeeTerm);

            payrollData.AddContractHead(contractValues);
        }

        private static void LoadSourceJson(string configFolder)
        {
            string configContent = "";

            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_SOURCE.JSON");

            try
            {
                StreamReader readerFile = new StreamReader(configFilePath, Encoding.GetEncoding("windows-1250"));

                configContent = readerFile.ReadToEnd();

                readerFile.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }

            var contractSourceConverter = new ArticleJsonConverter<ContractTermArticle>();
            var positionSourceConverter = new ArticleJsonConverter<PositionTermArticle>();

            JsonSerializerSettings settings = new JsonSerializerSettings();
            settings.Converters.Add(contractSourceConverter);
            settings.Converters.Add(positionSourceConverter);

            var ImportArticleCollection = JsonConvert.DeserializeObject<List<IArticleSource>>(configContent, settings);
        }

        private static void LoadSourceModel()
        {
            ArticleSourceCollection service = new ArticleSourceCollection();

            Assembly configAssembly = typeof(ElementsModule).Assembly;

            IArticleSourceFactory configFactory = new ArticleSourceFactory();

            service.InitConfigModel(configAssembly, configFactory);

            return;
        }
        private static void LoadConfigModel()
        {
            ArticleConfigCollection service = new ArticleConfigCollection();

            ArticleConfigFactory factory = new ArticleConfigFactory();

            service.InitConfigModel(factory);
        }

        private static void SaveConfigToJson(string configFolder)
        {
            IList<ArticleConfigNameJson> configList = new List<ArticleConfigNameJson>()
            {
                new ArticleConfigNameJson() {
                    Code = "ARTCODE_UNKNOWN", Role = "ARTROLE_UNKNOWN", ResolvePath = new string[] { }
                },
                new ArticleConfigNameJson() {
                    Code = "ARTCODE_CONTRACT_TERM", Role = "ARTROLE_CONTRACT_TERM", ResolvePath = new string[] { }
                },
                new ArticleConfigNameJson() {
                    Code = "ARTCODE_POSITION_TERM", Role = "ARTROLE_POSITION_TERM", ResolvePath = new string[] { "ARTCODE_CONTRACT_TERM" }
                },
            };

            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_CONFIG.JSON");
            ConfigJsonReader.SaveJsonData<ArticleConfigNameJson>(configFilePath, configList);
        }
        private static void loadConfigFromJson(string configFolder)
        {
            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_CONFIG.JSON");

            IList<ArticleConfigNameJson> configList = ConfigJsonReader.ReadJsonData<ArticleConfigNameJson>(configFilePath);
        }

        private static string ConfigFilesFolder()
        {
            string[] args = Environment.GetCommandLineArgs();

            string appExecutableFileNm = args[0];

            return ParentAppFolder(3, System.IO.Path.GetDirectoryName(appExecutableFileNm));
        }
        private static string ParentAppFolder(int levelsUp, string startDir)
        {
            string finalDir = startDir;
            for (int l = 0; l < levelsUp; l++)
            {
                finalDir = System.IO.Path.GetDirectoryName(finalDir);
            }
            return finalDir;
        }
    }
}
