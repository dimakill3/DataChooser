using _Assets.DataChooser.Scripts.DataChooser.Data;
using UnityEngine;

namespace _Assets.DataChooser.CharacterDemo.Scripts.Data
{
    [CreateAssetMenu(fileName = "Character Data", menuName = "Data/CharacterData")]
    public class CharacterData : ScriptableObject, IData
    {
        [SerializeField] private string _id;

        public string Id => _id;
        public string Name;
        public int Level;
        public Sprite Avatar;
        public GameObject Character3DView;
    }
}