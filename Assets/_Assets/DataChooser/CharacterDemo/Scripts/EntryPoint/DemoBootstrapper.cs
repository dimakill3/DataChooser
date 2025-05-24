using _Assets.DataChooser.CharacterDemo.Scripts.Assets;
using _Assets.DataChooser.CharacterDemo.Scripts.Data;
using _Assets.DataChooser.CharacterDemo.Scripts.UI.Factory;
using _Assets.DataChooser.Scripts.DataChooser.Data.Services.Selection;
using _Assets.DataChooser.Scripts.DataChooser.Data.Services.Storage;
using _Assets.DataChooser.Scripts.DataChooser.InputLogic;
using _Assets.DataChooser.Scripts.DataChooser.InputLogic.Data;
using _Assets.DataChooser.Scripts.DataChooser.Services;
using _Assets.DataChooser.Scripts.DataChooser.Services.AssetManagement;
using _Assets.DataChooser.Scripts.DataChooser.UI.Factory;
using UnityEngine;

namespace _Assets.DataChooser.CharacterDemo.Scripts.EntryPoint
{
    public class DemoBootstrapper : MonoBehaviour
    {
        [SerializeField] private MonoService _monoService;
        [SerializeField] private Transform _uiRoot;
        
        private IAssetProvider _assetProvider;
        private IGameDatabase _database;
        private ISelectionInputService _input;
        private IUIFactory _uiFactory;
        private ISelectionService _selectionService;
        private IChooseUIFactory _chooseUiFactory;

        private void Start()
        {
            RegisterServices();
            StartDemo();
        }

        private void RegisterServices()
        {
            _assetProvider = new AssetProvider();
            _database = new GameDatabase(_assetProvider);
            _chooseUiFactory = new ChooseUIFactory(_assetProvider, CharacterAssetPaths.PrefabPaths);
            _uiFactory = new UIFactory(_assetProvider, _uiRoot);

            RegisterInputService();
            
            _selectionService = new SelectionService<CharacterData>(_database, _input);
        }

        private void StartDemo()
        {
            var chooseWindow = _uiFactory.CreateChooseWindow();
            chooseWindow.Initialize(_selectionService, _chooseUiFactory);
        }

        private void RegisterInputService()
        {
            if (Application.platform == RuntimePlatform.IPhonePlayer || Application.platform == RuntimePlatform.Android)
            {
                var inputData = _assetProvider.Load<MobileInputData>(AssetPaths.GetInputDataPath(nameof(MobileInputData)));
                _input = new MobileSelectionInputService(_monoService, inputData);
            }
            else
            {
                var inputData = _assetProvider.Load<PcInputData>(AssetPaths.GetInputDataPath(nameof(PcInputData)));
                _input = new PcSelectionInputService(_monoService, inputData);
            }
        }
    }
}