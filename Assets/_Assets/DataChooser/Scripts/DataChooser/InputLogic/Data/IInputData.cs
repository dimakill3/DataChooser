using _Assets.DataChooser.Scripts.DataChooser.Data;

namespace _Assets.DataChooser.Scripts.DataChooser.InputLogic.Data
{
    public interface IInputData : IData
    {
        float MinimumSwipeDistance { get; }
    }
}