using _Assets.DataChooser.Scripts.DataChooser.Data.Services.Selection;
using _Assets.DataChooser.Scripts.DataChooser.Data.Services.Storage;
using _Assets.DataChooser.Scripts.DataChooser.InputLogic;

namespace _Assets.DataChooser.CharacterDemo.Scripts.Data.Selection
{
    public class CharacterSelectionService : SelectionService<CharacterData>
    {
        public CharacterSelectionService(IGameDatabase database, ISelectionInputService input, CharacterData initial = default)
            : base(database, input, initial)
        {
        }
    }
}