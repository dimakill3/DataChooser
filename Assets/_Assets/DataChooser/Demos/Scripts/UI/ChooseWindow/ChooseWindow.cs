using _Assets.DataChooser.Demos.CharacterDemo.Scripts.Utils;
using _Assets.DataChooser.Demos.Scripts.Services;
using _Assets.DataChooser.Scripts.DataChooser.Data.Services.Selection;
using _Assets.DataChooser.Scripts.DataChooser.UI.DataChooser;
using _Assets.DataChooser.Scripts.DataChooser.UI.Factory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.DataChooser.Demos.CharacterDemo.Scripts.UI.ChooseWindow
{
    public class ChooseWindow : MonoBehaviour
    {
        private const string Header = "Choose ";
        
        [SerializeField] private TMP_Text _header;
        [SerializeField] private ChoosePanel _choosePanel;
        [SerializeField] private Button _chooseButton;
        
        private ISelectionService _selectionService;
        private IActionOnChoose _actionOnChoose;

        public void Initialize(ISelectionService selectionService, IChooseUIFactory chooseUIFactory, IActionOnChoose actionOnChoose)
        {
            _actionOnChoose = actionOnChoose;
            _header.text = Header + DemoUtil.GetDataName(selectionService.Current);
            
            _selectionService = selectionService;
            _chooseButton.onClick.RemoveAllListeners();
            _chooseButton.onClick.AddListener(HandleChoose);

            _choosePanel.Initialize(selectionService, chooseUIFactory);
        }

        private void HandleChoose() =>
            _actionOnChoose.ActionOnChoose(_selectionService.Current);
    }
}