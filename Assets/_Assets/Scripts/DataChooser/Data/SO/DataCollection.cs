using System.Collections.Generic;
using UnityEngine;

namespace _Assets.Scripts.DataChooser.Data.SO
{
    public abstract class DataCollection<T> : ScriptableObject where T : ScriptableObject, IData
    {
        [SerializeField] private List<T> _items = new List<T>();
        
        public IReadOnlyList<T> Items => _items;
    }
}