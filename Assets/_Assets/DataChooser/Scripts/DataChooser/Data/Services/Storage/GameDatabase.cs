using System;
using System.Collections.Generic;
using System.Linq;
using _Assets.DataChooser.Scripts.DataChooser.Data.SO;
using _Assets.DataChooser.Scripts.DataChooser.Services;
using UnityEngine;

namespace _Assets.DataChooser.Scripts.DataChooser.Data.Services.Storage
{
    public class GameDatabase : IGameDatabase
    {
        private readonly IAssetProvider _assetProvider;
        private readonly Dictionary<Type, IList<IData>> _cache = new();

        public GameDatabase(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public IReadOnlyList<T> GetAll<T>() where T : ScriptableObject, IData
        {
            var type = typeof(T);
            if (!_cache.TryGetValue(type, out var list))
            {
                var path = $"Data/{type.Name}/Collection";
                var collection = _assetProvider.Load<DataCollection<T>>(path);

                list = collection.Items.Cast<IData>().ToList();
                _cache[type] = list;
            }
            return list.Cast<T>().ToList();
        }

        public T GetNext<T>(T current) where T : ScriptableObject, IData
        {
            var items = GetAll<T>();
            if (items.Count == 0) return null;
            var idx = items .Select((value, index) => (value, index))
                .FirstOrDefault(pair => EqualityComparer<T>.Default.Equals(pair.value, current))
                .index;
            var next = (idx + 1) % items.Count;
            return items[next];
        }

        public T GetPrevious<T>(T current) where T : ScriptableObject, IData
        {
            var items = GetAll<T>();
            if (items.Count == 0) return null;
            var idx = items.Select((value, index) => (value, index))
                .FirstOrDefault(pair => EqualityComparer<T>.Default.Equals(pair.value, current))
                .index;
            var prev = (idx - 1 + items.Count) % items.Count;
            return items[prev];
        }
    }
}