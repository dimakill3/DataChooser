using System;
using System.Collections.Generic;
using _Assets.DataChooser.Scripts.DataChooser.Data;
using _Assets.DataChooser.Scripts.DataChooser.Services.AssetManagement;
using _Assets.DataChooser.Scripts.DataChooser.UI.DataChooser;
using UnityEngine;
using Object = UnityEngine.Object;

namespace _Assets.DataChooser.Scripts.DataChooser.UI.Factory
{
    public class ChooseUIFactory : IChooseUIFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly Dictionary<Type, string> _prefabMap;
        
        public ChooseUIFactory(IAssetProvider assetProvider, Dictionary<Type, string> prefabMap)
        {
            _assetProvider = assetProvider;
            _prefabMap = prefabMap;
        }

        public ChosenDataView CreateChosenDataView(IData data, Transform parent)
        {
            var type = data.GetType();
            if (!_prefabMap.TryGetValue(type, out var path))
                throw new InvalidOperationException($"Не зарегистрирован префаб для {type.Name}");

            var prefab = _assetProvider.Load<GameObject>(path);
            var go = Object.Instantiate(prefab, parent, false);
            var chosenDataView = go.GetComponent<ChosenDataView>();
            if (chosenDataView == null)
                throw new InvalidOperationException($"Префаб {prefab.name} не содержит компонент ChosenDataView");
            
            return chosenDataView;
        }
    }

    public interface IChooseUIFactory
    {
        ChosenDataView CreateChosenDataView(IData data, Transform parent);
    }
}