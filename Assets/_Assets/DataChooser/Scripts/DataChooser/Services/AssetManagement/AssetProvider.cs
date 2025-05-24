using System;
using UnityEngine;

namespace _Assets.DataChooser.Scripts.DataChooser.Services.AssetManagement
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