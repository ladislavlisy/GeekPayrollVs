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
    using TargetItem = Module.Interfaces.Elements.IArticleTarget;
    using SourceCode = UInt16;
    using SourceItem = Module.Interfaces.Elements.IArticleSource;
    using SourceVals = Module.Interfaces.Elements.ISourceValues;
    using SourcePair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>>;
    using SourcePack = ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>;

    using ResultPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>>;
    using ResultPack = ResultMonad.Result<Module.Interfaces.Elements.IArticleResult, string>;

    using Module.Libs;
    using Module.Items;
    using Module.Interfaces;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Matrixus;
    using Module.Interfaces.Legalist;
    using Module.Interfaces.Permadom;
    using System.Reflection;
    using ResultMonad;
    using Elements;
    using Permadom;

    public class CalculusService : ICalculusService
    {
        private readonly Func<IArticleSource, TargetItem, Period, IPeriodProfile, IEnumerable<ResultPack>, IEnumerable<ResultPack>> _evaluateResultsFunc = (s, t, p, f, r) => s.EvaluateResults(t, p, f, r);

        IArticleConfigFactory ConfigFactory { get; set; }

        IArticleConfigProfile ConfigProfile { get; set; }

        IArticleSourceStore StreamSources { get; set; }
        IArticleResultStore StreamResults { get; set; }

        IEnumerable<SourcePair> EvaluationPath { get; set; }
        IEnumerable<ResultPair> EvaluationCase { get; set; }

        Assembly ModuleAssembly { get; set; }

        ConfigCode ContractCode { get; set; }
        ConfigCode PositionCode { get; set; }


        public CalculusService(IArticleConfigFactory configFactory, 
            IArticleConfigProfile configProfile)
        {
            this.ConfigFactory = configFactory;
            this.ConfigProfile = configProfile;
        }

        public void Initialize()
        {
            ModuleAssembly = typeof(ElementsService).Assembly;

            ContractCode = SymbolUtil.GetContractCode();
            PositionCode = SymbolUtil.GetPositionCode();

            IPermadomService payrollMemDbs = new PermadomService();

            var configRoleData = payrollMemDbs.GetArticleRoleDataList().ToList();

            var configCodeData = payrollMemDbs.GetArticleCodeDataList().ToList();
            
            ConfigProfile.Initialize(ModuleAssembly, configRoleData, configCodeData, ConfigFactory);

            StreamSources = new ArticleSourceStore(ConfigProfile);

            StreamResults = new ArticleResultStore();

            EvaluationPath = new List<SourcePair>();
        }

        public void EvaluateStore(IArticleSourceStore source, Period evalPeriod, IPeriodProfile evalProfile)
        {
            StreamSources.CopyModel(source);

            EvaluationPath = StreamSources.PrepareEvaluationPath(ContractCode, PositionCode);
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
