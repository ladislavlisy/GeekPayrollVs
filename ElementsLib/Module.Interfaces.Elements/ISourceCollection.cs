using System.Reflection;

namespace ElementsLib.Module.Interfaces.Elements
{
    public interface ISourceCollection<TConfig, TIndex, TValues>
    {
        TConfig CloneInstanceForCode(TIndex configCode, TValues sourceVals);
        TConfig FindInstanceForCode(TIndex configCode);

        void InitConfigModel(Assembly configAssembly, IArticleSourceFactory configFactory);
    }
}