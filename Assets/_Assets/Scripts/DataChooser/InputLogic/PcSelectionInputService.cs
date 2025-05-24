using System;
using _Assets.Scripts.DataChooser.InputLogic.Data;
using _Assets.Scripts.DataChooser.InputLogic.SwipeDetection;
using _Assets.Scripts.DataChooser.Services;
using UnityEngine;

namespace _Assets.Scripts.DataChooser.InputLogic
{
    public class PcSelectionInputService : ISelectionInputService
    {
        private readonly MonoService _monoService;
        private readonly PcInputData _inputData;
        private readonly ISwipeDetectorService _swipeDetectorService;

        public event Action OnPrevious;
        public event Action OnNext;
        
        public PcSelectionInputService(MonoService monoService, PcInputData inputData)
        {
            _monoService = monoService;
            _inputData = inputData;
            _swipeDetectorService = new SwipeDetectorService(_inputData);
            
            _monoService.OnTick += Update;
            _swipeDetectorService.Swipe += HandleSwipe;
        }

        public void Dispose()
        {
            _monoService.OnTick -= Update;
            _swipeDetectorService.Swipe -= HandleSwipe;
        }

        private void Update()
        {
            UpdateKeys();
            _swipeDetectorService.UpdateSwipe();
        }

        private void UpdateKeys()
        {
            if (Input.GetKeyDown(_inputData.SwipeDataLeftKey))
                OnPrevious?.Invoke();
            
            if (Input.GetKeyDown(_inputData.SwipeDataRightKey))
                OnNext?.Invoke();
        }

        private void HandleSwipe(SwipeDirection direction)
        {
            switch (direction)
            {
                case SwipeDirection.Left:
                    OnPrevious?.Invoke();
                    break;
                case SwipeDirection.Right:
                    OnNext?.Invoke();
                    break;
            }
        }
    }
}