using System;

namespace _Assets.Scripts.DataChooser.Data.Services.Selection
{
    public interface ISelectionService
    {
        event Action<IData> OnSelectionChanged;
        
        IData Current { get; }
        
        void SelectNext();
        void SelectPrevious();
    }
}