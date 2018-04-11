using ElementsLib.Module.Interfaces.Elements;

namespace ElementsLib.Module.Interfaces.Matrixus
{
    public interface IConfigCollection<TConfig, TIndex>
    {
        TConfig FindArticleConfig(TIndex modelCode);
        void InitConfigModel(IArticleConfigFactory configFactory);
    }
}