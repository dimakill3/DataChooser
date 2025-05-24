using System;
using System.Collections.Generic;
using _Assets.DataChooser.Demos.CharacterDemo.Scripts.Assets;
using _Assets.DataChooser.Demos.CharacterDemo.Scripts.Data;
using _Assets.DataChooser.Demos.LevelDemo.Scripts.Assets;
using _Assets.DataChooser.Demos.LevelDemo.Scripts.Data;

namespace _Assets.DataChooser.Demos.Scripts.Assets
{
    public static class DemoAssetPaths
    {
        public const string ChooseWindowPath = "Prefabs/UI/ChooseWindow";
        
        public static Dictionary<Type, string> PrefabPaths = new()
        {
            { typeof(CharacterData), CharacterAssetPaths.CharacterChosenView },
            { typeof(LevelData), LevelAssetPaths.LevelChosenView }
        };
    }
}