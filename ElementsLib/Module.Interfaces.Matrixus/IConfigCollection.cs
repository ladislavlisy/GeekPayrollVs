using ElementsLib.Module.Interfaces.Elements;

namespace ElementsLib.Interfaces.Matrixus
{
    public interface IConfigCollection<TConfig, TIndex>
    {
        TConfig FindArticleConfig(TIndex modelCode);
    }
}