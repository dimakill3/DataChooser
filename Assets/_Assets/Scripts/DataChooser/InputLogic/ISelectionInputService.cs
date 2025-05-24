using System;

namespace _Assets.Scripts.DataChooser.InputLogic
{
    public interface ISelectionInputService : IDisposable
    {
        event Action OnPrevious;
        event Action OnNext;
    }
}