using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultMonad.Extensions.ResultWithValueAndErrorMonad.OnSuccess;

namespace ElementsLib.Calculus
{
    using BundleCode = Module.Codes.ArticleCodeCz;
    using SymbolUtil = Module.Codes.ArticleCzCodeUtil;

    using ConfigCode = UInt16;
    using ConfigItem = Module.Interfaces.Elements.IArticleConfig;

    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using SourceCode = UInt16;
    using SourceItem = Module.Interfaces.Elements.IArticleSource;
    using SourceVals = Module.Interfaces.Elements.ISourceValues;
    using SourcePair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>>;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;

    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Module.Interfaces;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Matrixus;
    using System.Reflection;
    using Elements;
    using ResultMonad;
    using Module.Libs;
    using Module.Items;
    using Module.Interfaces.Legalist;

    public class CalculusService : ICalculusService
    {
        private readonly Func<IArticleSource, TargetItem, Period, IPeriodProfile, IEnumerable<ResultPack>, IEnumerable<ResultPack>> _evaluateResultsFunc = (s, t, p, f, r) => s.EvaluateResults(t, p, f, r);

        IArticleConfigFactory ConfigFactory { get; set; }

        IArticleSourceFactory SourceFactory { get; set; }

        IConfigCollection<ConfigItem, ConfigCode> ConfigBundler { get; set; }

        ISourceCollection<SourceItem, SourceCode, SourceVals> SourceBundler { get; set; }

        IArticleSourceStore StreamSources { get; set; }
        IArticleResultStore StreamResults { get; set; }

        IEnumerable<SourcePair> EvaluationPath { get; set; }
        IEnumerable<ResultPair> EvaluationCase { get; set; }

        Assembly ModuleAssembly { get; set; }

        ConfigCode ContractCode { get; set; }
        ConfigCode PositionCode { get; set; }


        public CalculusService(IArticleConfigFactory configFactory, 
            IArticleSourceFactory sourceFactory, 
            IConfigCollection<ConfigItem, ConfigCode> configBundler, 
            ISourceCollection<SourceItem, SourceCode, SourceVals> sourceBundler)
        {
            this.ConfigFactory = configFactory;
            this.SourceFactory = sourceFactory;
            this.ConfigBundler = configBundler;
            this.SourceBundler = sourceBundler;
        }

        public void Initialize()
        {
            ModuleAssembly = typeof(ElementsService).Assembly;

            ContractCode = SymbolUtil.GetContractCode();
            PositionCode = SymbolUtil.GetPositionCode();

            //ConfigBundler.InitConfigModel(ConfigFactory);

            SourceBundler.InitConfigModel(ModuleAssembly, SourceFactory);

            StreamSources = new ArticleSourceStore(SourceBundler);

            StreamResults = new ArticleResultStore();

            EvaluationPath = new List<SourcePair>();
        }

        public void EvaluateStore(IArticleSourceStore source, Period evalPeriod, IPeriodProfile evalProfile)
        {
            StreamSources.CopyModel(source);

            EvaluationPath = StreamSources.PrepareEvaluationPath(ConfigBundler, ContractCode, PositionCode);
            /*
            // payrollData.ModelList - Evaluate => Results 
            */
            EvaluationCase = EvaluateStream(EvaluationPath, evalPeriod, evalProfile);
        }

        public IEnumerable<ResultPair> EvaluateStream(IEnumerable<SourcePair> sourceStream, Period evalPeriod, IPeriodProfile evalProfile)
        {
            IEnumerable<ResultPack> initResults = new List<ResultPack>();

            return sourceStream.SelectMany((s) => EvaluateSourceItem(s, evalPeriod, evalProfile, initResults)).ToList();
        }

        private IEnumerable<ResultPair> EvaluateSourceItem(SourcePair sourceItem, Period evalPeriod, IPeriodProfile evalProfile, IEnumerable<ResultPack> evalResults)
        {
            TargetItem targetInResult = sourceItem.Key;
            SourcePack sourceInResult = sourceItem.Value;

            IEnumerable<ResultPack> resultList = sourceInResult.OnSuccessEvaluateToResultSet(targetInResult, evalPeriod, evalProfile, evalResults, _evaluateResultsFunc);

            return resultList.Select((r) => (new ResultPair(sourceItem.Key, r))).ToList();
        }

        public List<SourcePair> GetEvaluationPath()
        {
            return EvaluationPath.ToList();
        }
        public List<ResultPair> GetEvaluationCase()
        {
            return EvaluationCase.ToList();
        }
    }
}
