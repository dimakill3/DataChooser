using System;
using System.Collections;
using _Assets.DataChooser.Scripts.DataChooser.Services;
using UnityEngine.SceneManagement;

namespace _Assets.DataChooser.Demos.LevelDemo.Scripts.Services.SceneManagement
{
    public class SceneLoader : ISceneLoader
    {
        private readonly MonoService _monoService;

        public SceneLoader(MonoService monoService) =>
            _monoService = monoService;

        public void Load(string name, Action onLoaded = null) =>
            _monoService.StartCoroutine(LoadScene(name, onLoaded));

        private IEnumerator LoadScene(string name, Action onLoaded = null)
        {
            var sceneLoading = SceneManager.LoadSceneAsync(name);

            if (sceneLoading == null)
                yield break;
            
            while (!sceneLoading.isDone)
                yield return null;
            
            onLoaded?.Invoke();
        }
    }
}