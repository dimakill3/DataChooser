using System;
using _Assets.DataChooser.Demos.LevelDemo.Scripts.Data;
using _Assets.DataChooser.Demos.Scripts.Constants;
using _Assets.DataChooser.Scripts.DataChooser.Data;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Assets.DataChooser.Demos.LevelDemo.Scripts.UI.ChooseDataView
{
    public class LevelChosenDataView : DataChooser.Scripts.DataChooser.UI.DataChooser.ChosenDataView
    {
        [SerializeField] private TMP_Text _name;
        [SerializeField] private TMP_Text _description;
        [SerializeField] private Image _preview;
        
        public override void Initialize(IData data)
        {
            if (data is not LevelData levelData)
                throw new InvalidOperationException($"{nameof(LevelChosenDataView)} Ожидаются данные типа {nameof(LevelData)}, получены данные {data.GetType().Name}");
            
            Initialize(levelData);
        }
        
        private void Initialize(LevelData data)
        {
            _name.text = Labels.NameTemplate + data.Name;
            _description.text = Labels.DescriptionTemplate + data.Description;
            _preview.sprite = data.Preview;
        }
    }
}