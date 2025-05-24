using _Assets.DataChooser.Demos.CharacterDemo.Scripts.Data;
using _Assets.DataChooser.Demos.CharacterDemo.Scripts.Services;
using _Assets.DataChooser.Demos.Scripts.Assets;
using _Assets.DataChooser.Demos.Scripts.Enums;
using _Assets.DataChooser.Demos.Scripts.Services;
using _Assets.DataChooser.Demos.Scripts.UI.Factory;
using _Assets.DataChooser.Scripts.DataChooser.Data.Services.Selection;
using _Assets.DataChooser.Scripts.DataChooser.Data.Services.Storage;
using _Assets.DataChooser.Scripts.DataChooser.InputLogic;
using _Assets.DataChooser.Scripts.DataChooser.InputLogic.Data;
using _Assets.DataChooser.Scripts.DataChooser.Services;
using _Assets.DataChooser.Scripts.DataChooser.Services.AssetManagement;
using _Assets.DataChooser.Scripts.DataChooser.UI.Factory;
using UnityEngine;

namespace _Assets.DataChooser.Demos.Scripts.EntryPoint
{
    public class DemoBootstrapper : MonoBehaviour
    {
        [SerializeField] private MonoService _monoService;
        [SerializeField] private Transform _uiRoot;
        [SerializeField] private DemoSetup _demoSetup;
        
        private IAssetProvider _assetProvider;
        private IGameDatabase _database;
        private ISelectionInputService _input;
        private IUIFactory _uiFactory;
        private ISelectionService _selectionService;
        private IChooseUIFactory _chooseUiFactory;
        private IActionOnChoose _actionOnChoose;

        private void Start()
        {
            RegisterServices();
            StartDemo();
        }

        private void RegisterServices()
        {
            _assetProvider = new AssetProvider();
            _database = new GameDatabase(_assetProvider);
            _chooseUiFactory = new ChooseUIFactory(_assetProvider, DemoAssetPaths.PrefabPaths);
            _uiFactory = new UIFactory(_assetProvider, _uiRoot);

            RegisterInputService();

            switch (_demoSetup)
            {
                case DemoSetup.Character:
                    _selectionService = new SelectionService<CharacterData>(_database, _input);
                    _actionOnChoose = new CharacterActionOnChoose();
                    break;
            }
        }

        private void StartDemo()
        {
            var chooseWindow = _uiFactory.CreateChooseWindow();
            chooseWindow.Initialize(_selectionService, _chooseUiFactory, _actionOnChoose);
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