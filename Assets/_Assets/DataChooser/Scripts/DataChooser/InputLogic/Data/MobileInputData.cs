using UnityEngine;

namespace _Assets.DataChooser.Scripts.DataChooser.InputLogic.Data
{
    [CreateAssetMenu(fileName = "MobileInputData", menuName = "Configs/MobileInputData")]
    public class MobileInputData : ScriptableObject, IInputData
    {
        [SerializeField] private string _id;
        [SerializeField] private float _minimumSwipeDistance;
        
        public string Id => _id;
        public float MinimumSwipeDistance => _minimumSwipeDistance;
    }
}