using System;
using UnityEngine;

namespace _Assets.Scripts.DataChooser.Services
{
    public class MonoService : MonoBehaviour
    {
        public event Action OnTick;

        private void Update() =>
            OnTick?.Invoke();
    }
}