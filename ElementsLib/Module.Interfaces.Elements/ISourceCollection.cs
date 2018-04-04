using System.Reflection;

namespace ElementsLib.Module.Interfaces.Elements
{
    public interface ISourceCollection<TConfig, TIndex>
    {
        TConfig CloneInstanceForCode(TIndex configCode);
        TConfig FindInstanceForCode(TIndex configCode);

        void InitConfigModel(Assembly configAssembly, IArticleSourceFactory configFactory);
    }
}