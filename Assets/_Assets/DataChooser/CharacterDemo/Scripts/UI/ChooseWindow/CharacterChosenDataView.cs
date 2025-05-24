using System;
using _Assets.DataChooser.CharacterDemo.Scripts.Data;
using _Assets.DataChooser.Scripts.DataChooser.Data;
using _Assets.DataChooser.Scripts.DataChooser.UI.DataChooser;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.DataChooser.CharacterDemo.Scripts.UI.ChooseWindow
{
    public class CharacterChosenDataView : ChosenDataView
    {
        private const string NameTemplate = "Name: ";
        private const string LevelTemplate = "Level: ";
        
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _level;
        [SerializeField] private Image _icon;
        [SerializeField] private Transform _3DViewParent;

        private GameObject _character3DView;
        
        public override void Initialize(IData data)
        {
            if (data is not CharacterData characterData)
                throw new InvalidOperationException($"{nameof(CharacterChosenDataView)} Ожидаются данные типа {nameof(CharacterData)}, получены данные {data.GetType().Name}");
            
            Initialize(characterData);
        }

        private void Initialize(CharacterData data)
        {
            _name.text = NameTemplate + data.Name;
            _level.text = LevelTemplate + data.Level;
            _icon.sprite = data.Avatar;
            
            if (_character3DView != null)
                Destroy(_character3DView);
            
            _character3DView = Instantiate(data.Character3DView, _3DViewParent);
        }
    }
}