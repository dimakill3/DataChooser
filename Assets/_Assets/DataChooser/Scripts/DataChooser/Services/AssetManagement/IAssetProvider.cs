namespace _Assets.DataChooser.Scripts.DataChooser.Services.AssetManagement
{
    public interface IAssetProvider
    {
        T Load<T>(string path) where T : UnityEngine.Object;
    }
}