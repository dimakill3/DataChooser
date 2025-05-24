using System;
using _Assets.Scripts.DataChooser.InputLogic.Data;
using _Assets.Scripts.DataChooser.InputLogic.SwipeDetection;
using _Assets.Scripts.DataChooser.Services;

namespace _Assets.Scripts.DataChooser.InputLogic
{
    public class MobileSelectionInputService : ISelectionInputService
    {
        private readonly MonoService _monoService;
        private readonly ISwipeDetectorService _swipeDetectorService;
        
        public event Action OnPrevious;
        public event Action OnNext;

        public MobileSelectionInputService(MonoService monoService, MobileInputData inputData)
        {
            _monoService = monoService;
            _swipeDetectorService = new SwipeDetectorService(inputData);
            
            _monoService.OnTick += Update;
            _swipeDetectorService.Swipe += HandleSwipe;
        }

        public void Dispose()
        {
            _monoService.OnTick -= Update;
            _swipeDetectorService.Swipe -= HandleSwipe;
        }

        private void Update() =>
            _swipeDetectorService.UpdateSwipe();
        
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