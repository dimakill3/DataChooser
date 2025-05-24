using _Assets.DataChooser.Scripts.DataChooser.Data;
using _Assets.DataChooser.Scripts.DataChooser.Data.Services.Selection;
using _Assets.DataChooser.Scripts.DataChooser.UI.Factory;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.DataChooser.Scripts.DataChooser.UI.DataChooser
{
    public class ChoosePanel : MonoBehaviour
    {
        [SerializeField] private Button _swipeLeft;
        [SerializeField] private Button _swipeRight;
        [SerializeField] private Transform _chosenDataViewParent;
        
        private ISelectionService _selectionService;
        private ChosenDataView _currentView;

        public virtual void Initialize(ISelectionService selectionService, IChooseUIFactory chooseUIFactory)
        {
            _selectionService = selectionService;
            _currentView = chooseUIFactory.CreateChosenDataView(_selectionService.Current, _chosenDataViewParent);
            _currentView.Initialize(_selectionService.Current);

            _selectionService.OnSelectionChanged += ChangeSelection;
            _swipeLeft.onClick.AddListener(SwipeLeft);
            _swipeRight.onClick.AddListener(SwipeRight);
        }

        protected virtual void OnDestroy()
        {
            if (_selectionService != null)
                _selectionService.OnSelectionChanged -= ChangeSelection;
            _swipeLeft.onClick.RemoveListener(SwipeLeft);
            _swipeRight.onClick.RemoveListener(SwipeRight);

            Destroy(_currentView.gameObject);
        }

        protected virtual void SwipeLeft() =>
            _selectionService.SelectPrevious();

        protected virtual void SwipeRight() =>
            _selectionService.SelectNext();

        protected virtual void ChangeSelection(IData data) =>
            _currentView.Initialize(data);
    }
}