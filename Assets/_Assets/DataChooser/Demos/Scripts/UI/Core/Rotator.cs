using UnityEngine;

namespace _Assets.DataChooser.Demos.Scripts.UI.Core
{
    public class Rotator : MonoBehaviour
    {
        [SerializeField] private float _rotationSpeed = 30f;
        
        private void FixedUpdate()
        {
            var rotated = transform.localEulerAngles;
            rotated.y += _rotationSpeed * Time.fixedDeltaTime % 360;
            transform.localEulerAngles = rotated;
        }
    }
}