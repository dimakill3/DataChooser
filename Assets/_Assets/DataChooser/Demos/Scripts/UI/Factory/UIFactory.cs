using _Assets.DataChooser.Demos.CharacterDemo.Scripts.Assets;
using _Assets.DataChooser.Demos.Scripts.Assets;
using _Assets.DataChooser.Scripts.DataChooser.Services.AssetManagement;
using UnityEngine;

namespace _Assets.DataChooser.Demos.Scripts.UI.Factory
{
    public class UIFactory : IUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly Transform _uiRoot;
        
        public UIFactory(IAssetProvider assetProvider, Transform uiRoot)
        {
            _assetProvider = assetProvider;
            _uiRoot = uiRoot;
        }

        public ChooseWindow.ChooseWindow CreateChooseWindow()
        {
            var prefab = _assetProvider.Load<ChooseWindow.ChooseWindow>(DemoAssetPaths.ChooseWindowPath);
            var chooseWindow = Object.Instantiate(prefab, _uiRoot);
            return chooseWindow;
        }
    }
}