using System;
using _Assets.DataChooser.Demos.LevelDemo.Scripts.Data;
using _Assets.DataChooser.Demos.LevelDemo.Scripts.Services.SceneManagement;
using _Assets.DataChooser.Demos.Scripts.Services;
using _Assets.DataChooser.Scripts.DataChooser.Data;

namespace _Assets.DataChooser.Demos.LevelDemo.Scripts.Services
{
    public class LevelActionOnChoose : IActionOnChoose
    {
        private ISceneLoader _sceneLoader;

        public LevelActionOnChoose(ISceneLoader sceneLoader) =>
            _sceneLoader = sceneLoader;

        public void ActionOnChoose(IData data)
        {
            if (data is not LevelData levelData)
                return;

            ActionOnChoose(levelData);
        }

        private void ActionOnChoose(LevelData data) =>
            _sceneLoader.Load(data.SceneId);
    }
}