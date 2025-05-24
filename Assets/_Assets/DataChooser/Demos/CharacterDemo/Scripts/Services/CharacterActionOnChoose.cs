using _Assets.DataChooser.Demos.CharacterDemo.Scripts.Data;
using _Assets.DataChooser.Demos.Scripts.Services;
using _Assets.DataChooser.Scripts.DataChooser.Data;

namespace _Assets.DataChooser.Demos.CharacterDemo.Scripts.Services
{
    public class CharacterActionOnChoose : IActionOnChoose
    {
        public void ActionOnChoose(IData data)
        {
            if (data is not CharacterData characterData)
                return;

            ActionOnChoose(characterData);
        }

        private void ActionOnChoose(CharacterData data)
        {
            // Your Logic Here
        }
    }
}