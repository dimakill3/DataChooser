using System;

namespace _Assets.DataChooser.Scripts.DataChooser.InputLogic
{
    public interface ISelectionInputService : IDisposable
    {
        event Action OnPrevious;
        event Action OnNext;
    }
}