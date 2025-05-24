using _Assets.DataChooser.Demos.CharacterDemo.Scripts.Data;
using _Assets.DataChooser.Scripts.DataChooser.Data;

namespace _Assets.DataChooser.Demos.Scripts.Utils
{
    public static class DemoUtil
    {
        public static string GetDataName(IData data)
        {
            return data switch
            {
                CharacterData => "Character",
                _ => ""
            };
        }
    }
}