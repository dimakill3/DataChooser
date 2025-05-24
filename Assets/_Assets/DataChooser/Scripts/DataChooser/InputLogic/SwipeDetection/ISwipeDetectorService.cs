using System;

namespace _Assets.DataChooser.Scripts.DataChooser.InputLogic.SwipeDetection
{
    public interface ISwipeDetectorService
    {
        public event Action<SwipeDirection> Swipe;
        
        public void UpdateSwipe();
    }
}