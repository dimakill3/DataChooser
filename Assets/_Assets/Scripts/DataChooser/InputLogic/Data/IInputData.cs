using _Assets.Scripts.DataChooser.Data;

namespace _Assets.Scripts.DataChooser.InputLogic.Data
{
    public interface IInputData : IData
    {
        float MinimumSwipeDistance { get; }
    }
}