using System;
using System.Linq;
using _Assets.DataChooser.Scripts.DataChooser.Data.Services.Storage;
using _Assets.DataChooser.Scripts.DataChooser.InputLogic;
using UnityEngine;

namespace _Assets.DataChooser.Scripts.DataChooser.Data.Services.Selection
{
    public class SelectionService<T> : ISelectionService where T : ScriptableObject, IData
    {
        public event Action<IData> OnSelectionChanged;
        
        private readonly IGameDatabase _database;
        private readonly ISelectionInputService _input;
        private T _current;
        
        IData ISelectionService.Current => _current;


        public SelectionService(IGameDatabase database, ISelectionInputService input, T initial = default)
        {
            _database = database;
            _input = input;
            var all = _database.GetAll<T>();
            _current = initial != null && all.Contains(initial) 
                ? initial 
                : all.FirstOrDefault();
            _input.OnPrevious += SelectNext;
            _input.OnNext += SelectPrevious;
        }

        public void SelectNext() =>
            Change(_current = _database.GetNext(_current));
        public void SelectPrevious() =>
            Change(_database.GetPrevious(_current));
        
        private void Change(T next)
        {
            if (next == null || Equals(next, _current))
                return;
            
            _current = next;
            OnSelectionChanged?.Invoke(_current);
        }
    }
}