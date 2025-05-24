using _Assets.DataChooser.Scripts.DataChooser.Data.Services.Selection;
using _Assets.DataChooser.Scripts.DataChooser.Data.Services.Storage;
using _Assets.DataChooser.Scripts.DataChooser.InputLogic;

namespace _Assets.DataChooser.Demos.LevelDemo.Scripts.Data.Selection
{
    public class LevelSelectionService : SelectionService<LevelData>
    {
        public LevelSelectionService(IGameDatabase database, ISelectionInputService input, LevelData initial = default)
            : base(database, input, initial)
        {
        }
    }
}