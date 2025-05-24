namespace _Assets.DataChooser.Scripts.DataChooser.Services
{
    public interface IAssetProvider
    {
        T Load<T>(string path) where T : UnityEngine.Object;
    }
}