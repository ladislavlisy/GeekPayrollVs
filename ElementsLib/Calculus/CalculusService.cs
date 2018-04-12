using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElementsLib.Calculus
{
    using BundleCode = Module.Codes.ArticleCzCode;
    using SymbolUtil = Module.Codes.ArticleCzCodeUtil;

    using ConfigCode = UInt16;
    using ConfigItem = Module.Interfaces.Elements.IArticleConfig;

    using SourceCode = UInt16;
    using SourceItem = Module.Interfaces.Elements.IArticleSource;
    using SourceVals = Module.Interfaces.Elements.ISourceValues;
    using TargetPair = KeyValuePair<Module.Interfaces.Elements.IArticleTarget, ResultMonad.Result<Module.Interfaces.Elements.IArticleSource, string>>;

    using Module.Interfaces;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Matrixus;
    using System.Reflection;
    using Elements;

    public class CalculusService : ICalculusService
    {
        IArticleConfigFactory ConfigFactory { get; set; }

        IArticleSourceFactory SourceFactory { get; set; }

        IConfigCollection<ConfigItem, ConfigCode> ConfigBundler { get; set; }

        ISourceCollection<SourceItem, SourceCode, SourceVals> SourceBundler { get; set; }

        IArticleBucket SourceStreamy { get; set; }

        IList<TargetPair> EvaluationPath { get; set; }

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

            ConfigBundler.InitConfigModel(ConfigFactory);

            SourceBundler.InitConfigModel(ModuleAssembly, SourceFactory);

            SourceStreamy = new ArticleBucket(SourceBundler);

            EvaluationPath = new List<TargetPair>();
        }

        public void EvaluateBucket(IArticleBucket source)
        {
            SourceStreamy.CopyTargets(source);

            EvaluationPath = SourceStreamy.PrepareEvaluationPath(ConfigBundler, ContractCode, PositionCode);
            /*
            // payrollData.ModelList - Evaluate => Results 
            */
        }

        public IList<TargetPair> GetEvaluationPath()
        {
            return EvaluationPath.ToList();
        }
    }
}
