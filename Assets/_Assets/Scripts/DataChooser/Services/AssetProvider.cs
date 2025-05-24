using System;
using UnityEngine;

namespace _Assets.Scripts.DataChooser.Services
{
    public class AssetProvider : IAssetProvider
    {
        public T Load<T>(string path) where T : UnityEngine.Object
        {
            var asset = Resources.Load<T>(path);
            if (asset == null)
                throw new InvalidOperationException($"Не удалось загрузить ресурс по пути '{path}' типа {typeof(T).Name}");
            return asset;
        }
    }
}