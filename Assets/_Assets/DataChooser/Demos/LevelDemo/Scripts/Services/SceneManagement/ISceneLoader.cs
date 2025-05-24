using System;

namespace _Assets.DataChooser.Demos.LevelDemo.Scripts.Services.SceneManagement
{
    public interface ISceneLoader
    {
        void Load(string name, Action onLoaded = null);
    }
}