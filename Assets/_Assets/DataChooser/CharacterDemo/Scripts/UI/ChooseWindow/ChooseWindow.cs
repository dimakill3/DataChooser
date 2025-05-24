using _Assets.DataChooser.CharacterDemo.Scripts.Utils;
using _Assets.DataChooser.Scripts.DataChooser.Data.Services.Selection;
using _Assets.DataChooser.Scripts.DataChooser.UI.DataChooser;
using _Assets.DataChooser.Scripts.DataChooser.UI.Factory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.DataChooser.CharacterDemo.Scripts.UI.ChooseWindow
{
    public class ChooseWindow : MonoBehaviour
    {
        private const string Header = "Choose ";
        
        // public event Action<IData> OnChosen;
        
        [SerializeField] private TMP_Text _header;
        [SerializeField] private ChoosePanel _choosePanel;
        [SerializeField] private Button _chooseButton;
        
        private ISelectionService _selectionService;

        public void Initialize(ISelectionService selectionService, IChooseUIFactory chooseUIFactory)
        {
            _header.text = Header + CharacterUtil.GetDataName(selectionService.Current);
            
            _selectionService = selectionService;
            _chooseButton.onClick.RemoveAllListeners();
            _chooseButton.onClick.AddListener(HandleChoose);

            _choosePanel.Initialize(selectionService, chooseUIFactory);
        }

        private void HandleChoose()
        {
            // Your Logic Here. For example:
            // OnChosen?.Invoke(_selectionService.Current);
        }
    }
}