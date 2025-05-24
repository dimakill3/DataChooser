using UnityEngine;

namespace _Assets.DataChooser.Scripts.DataChooser.InputLogic.Data
{
    [CreateAssetMenu(fileName = "PcInputData", menuName = "Configs/PcInputData")]
    public class PcInputData : ScriptableObject, IInputData
    {
        [SerializeField] private string _id;
        [SerializeField] private float _minimumSwipeDistance;

        public string Id => _id;
        public float MinimumSwipeDistance => _minimumSwipeDistance;
        public KeyCode SwipeDataLeftKey = KeyCode.LeftArrow;
        public KeyCode SwipeDataRightKey = KeyCode.RightArrow;
    }
}