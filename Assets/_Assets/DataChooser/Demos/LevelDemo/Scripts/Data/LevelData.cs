using _Assets.DataChooser.Scripts.DataChooser.Data;
using UnityEngine;

namespace _Assets.DataChooser.Demos.LevelDemo.Scripts.Data
{
    [CreateAssetMenu(fileName = "Level Data", menuName = "Data/LevelData")]
    public class LevelData : ScriptableObject, IData
    {
        [SerializeField] private string _id;

        public string Id => _id;
        public string Name;
        [TextArea]
        public string Description;
        public Sprite Preview;
        public string SceneId;
    }
}