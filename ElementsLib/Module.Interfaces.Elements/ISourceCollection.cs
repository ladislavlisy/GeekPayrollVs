using System.Reflection;

namespace ElementsLib.Module.Interfaces.Elements
{
    public interface ISourceCollection<TConfig, TIndex, TValues>
    {
        ResultMonad.Result<TConfig, string> CloneInstanceForCode(TIndex configCode, TValues sourceVals);
        ResultMonad.Result<TConfig, string> FindInstanceForCode(TIndex configCode);

        void InitConfigModel(Assembly configAssembly, IArticleSourceFactory configFactory);
    }
}