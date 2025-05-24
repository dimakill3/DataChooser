using System;
using System.Collections.Generic;
using _Assets.DataChooser.CharacterDemo.Scripts.Data;

namespace _Assets.DataChooser.CharacterDemo.Scripts.Assets
{
    public static class CharacterAssetPaths
    {
        public const string ChooseWindowPath = "Prefabs/UI/CharacterChooseWindow";
        public const string CharacterChosenView = "Prefabs/UI/CharacterChosenDataView";
        
        public static Dictionary<Type, string> PrefabPaths = new()
        {
            { typeof(CharacterData), CharacterAssetPaths.CharacterChosenView }
        };
    }
}