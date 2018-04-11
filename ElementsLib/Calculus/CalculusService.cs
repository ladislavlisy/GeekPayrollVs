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

    using Module.Interfaces;
    using Module.Interfaces.Elements;
    using Module.Interfaces.Matrixus;
    using System.Reflection;
    using Elements;
    using Module.Codes;

    public class CalculusService : ICalculusService
    {
        IArticleConfigFactory ConfigFactory { get; set; }

        IArticleSourceFactory SourceFactory { get; set; }

        IConfigCollection<ConfigItem, ConfigCode> ConfigBundler { get; set; }

        ISourceCollection<SourceItem, SourceCode, SourceVals> SourceBundler { get; set; }

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
            Assembly moduleAssembly = typeof(ElementsService).Assembly;

            ConfigCode contractCode = SymbolUtil.GetContractCode();
            ConfigCode positionCode = SymbolUtil.GetPositionCode();

            ConfigBundler.InitConfigModel(ConfigFactory);

            SourceBundler.InitConfigModel(moduleAssembly, SourceFactory);
        }

        public void EvaluateBucket()
        {
            /*
            var payrollData = new ArticleBucket(payrollSource);

            IEnumerable<ArticleTarget> targetsInit = payrollData.GetTargets();

            ConfigCode contractCode = MarkUtil.GetContractCode();
            ConfigCode positionCode = MarkUtil.GetPositionCode();

            IEnumerable<ArticleTarget> targetsCalc = payrollConfig.GetTargets(targetsInit, contractCode, positionCode);

            foreach (var calc in targetsCalc)
            {
                if (payrollData.Keys.SingleOrDefault((s) => (s.IsEqualToHeadPartCode(calc.Head, calc.Part, calc.Code)))==null)
                {
                    payrollData.AddGeneralItem(calc.Head, calc.Part, calc.Code, calc.Seed, null);
                }
            }

            IList<TargetPair> evaluationSteps = payrollData.PrepareEvaluationPath(payrollConfig.ModelPath);
            // Sort <CODE, SORT> SortedConfig
            // payrollData.ModelList + ResolvePath - Codes => Sort by SortedConfig
            // payrollData.ModelList - Evaluate => Results 

             */
        }
    }
}
