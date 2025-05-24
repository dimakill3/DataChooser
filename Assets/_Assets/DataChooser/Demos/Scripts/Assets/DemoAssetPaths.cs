using System;
using System.Collections.Generic;
using _Assets.DataChooser.Demos.CharacterDemo.Scripts.Assets;
using _Assets.DataChooser.Demos.CharacterDemo.Scripts.Data;

namespace _Assets.DataChooser.Demos.Scripts.Assets
{
    public static class DemoAssetPaths
    {
        public static Dictionary<Type, string> PrefabPaths = new()
        {
            { typeof(CharacterData), CharacterAssetPaths.CharacterChosenView }
        };
    }
}