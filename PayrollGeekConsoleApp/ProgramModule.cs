﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Newtonsoft.Json;

using ElementsLib;
using ElementsLib.Matrixus.Config;
using ElementsLib.Elements.Config;
using ElementsLib.Elements.Config.Source;
using ElementsLib.Elements.Config.Articles;
using ElementsLib.Elements;
using ElementsLib.Legalist.Constants;
using ElementsLib.Module.Json;
using ElementsLib.Module.Interfaces.Elements;
using ElementsLib.Module.Codes;
using ElementsLib.Matrixus.Source;

namespace PayrollGeekConsoleApp
{
    using ConfigCodeEnum = ArticleCodeCz;
    using MarkUtil = ArticleCzCodeUtil;
    using HolderHead = UInt16;
    using HolderPart = UInt16;
    using ConfigCode = UInt16;

    using HolderItem = ElementsLib.Module.Interfaces.Elements.IArticleHolder;
    using SourceVals = ResultMonad.Result<ElementsLib.Module.Interfaces.Elements.IArticleSource, string>;
    using SourcePair = KeyValuePair<ElementsLib.Module.Interfaces.Elements.IArticleHolder, ResultMonad.Result<ElementsLib.Module.Interfaces.Elements.IArticleSource, string>>;
    using ResultPair = KeyValuePair<ElementsLib.Module.Interfaces.Elements.IArticleHolder, ResultMonad.Result<ElementsLib.Module.Interfaces.Elements.IArticleResult, string>>;
    using ResultPack = ResultMonad.Result<ElementsLib.Module.Interfaces.Elements.IArticleResult, string>;

    using ElementsLib.Module.Interfaces;
    using ElementsLib.Calculus;
    using ElementsLib.Module.Libs;
    using ElementsLib.Module.Items;
    using ElementsLib.Module.Interfaces.Legalist;
    using ElementsLib.Legalist.Config;
    using ElementsLib.Matrixus;
    using ElementsLib.Module.Interfaces.Permadom;
    using ElementsLib.Permadom;

    static class ProgramModule
    {
        public static void CreatePayrollData(string configFolder)
        {
            Assembly configAssembly = typeof(ElementsService).Assembly;

            IPermadomService payrollMemDbs = new PermadomService();

            IMatrixusService payrollMatrix = new SimpleMatrixusService();

            var configCodeData = payrollMemDbs.GetArticleCodeDataList().ToList();

            var configRoleData = payrollMemDbs.GetArticleRoleDataList().ToList();

            ArticleConfigFactory articleConfigFactory = new ArticleConfigFactory();

            ArticleCodeCollection payrollConfig = new ArticleCodeCollection();
            
            payrollConfig.LoadConfigData(configCodeData, articleConfigFactory);

            IArticleSourceFactory articleSourceFactory = new ArticleSourceFactory();

            ArticleStubCollection payrollSource = new ArticleStubCollection();
            
            payrollSource.InitConfigModel(configAssembly, articleSourceFactory);


            var payrollData = new ArticleSourceStore(payrollSource);

            #region TEST_VALUES

            DateTime? TestDateFrom = new DateTime(2010, 1, 1);
            DateTime? TestDateStop = null;
            var TestEmployeeTerm = WorkEmployTerms.WORKTERM_EMPLOYMENT_1;
            var TestPositionTerm = WorkPositionType.POSITION_EXCLUSIVE;
            Int32 TestShiftLiable = 0;
            Int32 TestShiftActual = 0;
            WorkScheduleType TestScheduleType = WorkScheduleType.SCHEDULE_NORMALY_WEEK;
            
            #endregion

            ArticleData[] payrollLoad = new ArticleData[]
            {
                new ArticleData() {
                    Head = 0, Part = 0, Seed = 1, Code = (UInt16)ArticleCodeCz.TARGET_CONTRACT_TERM,
                    Tags = new ContractTermSource(TestDateFrom, TestDateStop, TestEmployeeTerm),
                },
                new ArticleData() {
                    Head = 1, Part = 0, Seed = 1, Code = (UInt16)ArticleCodeCz.TARGET_POSITION_TERM,
                    Tags = new PositionTermSource(TestDateFrom, TestDateStop, TestPositionTerm),
                },
                new ArticleData() {
                    Head = 1, Part = 1, Seed = 1, Code = (UInt16)ArticleCodeCz.TARGET_POSITION_SCHEDULE,
                    Tags = new PositionScheduleSource(TestShiftLiable, TestShiftActual, TestScheduleType),
                },
                new ArticleData() {
                    Head = 1, Part = 0, Seed = 1, Code = (UInt16)ArticleCodeCz.TARGET_CONTRACT_WORKING,
                    Tags = null,
                },
                //TARGET_POSITION_TIMESHEET,
                //TARGET_POSITION_WORKING,
                //TARGET_POSITION_ABSENCE,
                //TARGET_CONTRACT_TIMESHEET,
                //TARGET_CONTRACT_WORKING,
                //TARGET_CONTRACT_ABSENCE,
            };

            foreach (var data in payrollLoad)
            {
                payrollData.StoreGeneralItem(data.Head, data.Part, data.Code, data.Seed, data.Tags);
            }

            ICalculusService payrollService = new CalculusService(
                articleConfigFactory, articleSourceFactory, payrollConfig, payrollSource);

            payrollService.Initialize();

            IBundleVersionFactory payrollExpertFactory = new BundleVersionFactory();

            IBundleVersionCollection payrollExpert = new BundleVersionCollection();

            payrollExpert.InitBundleProfiles(configAssembly, payrollExpertFactory);

            Period evalPeriod = new Period(2018, 1);

            IPeriodProfile evalProfile = payrollExpert.GetPeriodProfile(evalPeriod);

            payrollService.EvaluateStore(payrollData, evalPeriod, evalProfile);

            List<SourcePair> evaluationPath = payrollService.GetEvaluationPath();

            List<ResultPair> evaluationCase = payrollService.GetEvaluationCase();

            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_PAYROLL.TXT");

            try
            {
                StreamWriter writerFile = new StreamWriter(configFilePath, false, Encoding.GetEncoding("windows-1250"));

                configCodeData.ForEach((c) => writerFile.WriteLine(c.ToString()));
                          
                configRoleData.ForEach((c) => writerFile.WriteLine(c.ToString()));

                evaluationPath.ForEach((c) => writerFile.WriteLine(c.Description()));

                evaluationCase.ForEach((c) => writerFile.WriteLine(c.Description()));

                writerFile.Flush();

                writerFile.Close();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.Print(ex.Message);
            }
        }

        public static void LoadSourceJson(string configFolder)
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

            // var ImportArticleCollection = JsonConvert.DeserializeObject<List<IArticleSource>>(configContent, settings);
        }

        public static void LoadSourceModel()
        {
            ArticleStubCollection service = new ArticleStubCollection();

            Assembly configAssembly = typeof(ElementsService).Assembly;

            IArticleSourceFactory configFactory = new ArticleSourceFactory();

            service.InitConfigModel(configAssembly, configFactory);

            return;
        }
        public static void SaveConfigToJson(string configFolder)
        {
            IList<ArticleConfigNameJson> configList = new List<ArticleConfigNameJson>()
            {
                new ArticleConfigNameJson() {
                    Code = "TARGET_UNKNOWN", Role = "METHOD_UNKNOWN", ResolvePath = new string[] { }
                },
                new ArticleConfigNameJson() {
                    Code = "TARGET_CONTRACT_TERM", Role = "METHOD_CONTRACT_TERM", ResolvePath = new string[] { }
                },
                new ArticleConfigNameJson() {
                    Code = "TARGET_POSITION_TERM", Role = "METHOD_POSITION_TERM", ResolvePath = new string[] { "TARGET_CONTRACT_TERM" }
                },
            };

            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_CONFIG.JSON");
            ConfigJsonReader.SaveJsonData<ArticleConfigNameJson>(configFilePath, configList);
        }
        public static void loadConfigFromJson(string configFolder)
        {
            string configFilePath = System.IO.Path.Combine(configFolder, "ARTICLES_CONFIG.JSON");

            IList<ArticleConfigNameJson> configList = ConfigJsonReader.ReadJsonData<ArticleConfigNameJson>(configFilePath);
        }

    }
}
