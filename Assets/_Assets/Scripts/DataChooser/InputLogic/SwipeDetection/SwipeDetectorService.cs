using System;
using _Assets.Scripts.DataChooser.InputLogic.Data;
using UnityEngine;

namespace _Assets.Scripts.DataChooser.InputLogic.SwipeDetection
{
    public enum SwipeDirection
    {
        Top = 0,
        Down = 1,
        Left = 2,
        Right = 3
    }

    public class SwipeDetectorService : ISwipeDetectorService
    {
        public event Action<SwipeDirection> Swipe;

        private readonly IInputData _inputData;
        private Vector2 _startPosition;
        private bool _isSwiping = false;
        
        public SwipeDetectorService(IInputData inputData) =>
            _inputData = inputData;

        public void UpdateSwipe()
        {
            var currentPos = Vector2.zero;
            var ended = false;
            
#if UNITY_ANDROID || UNITY_IOS

            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                currentPos = touch.position;

                if (touch.phase == TouchPhase.Began)
                    StartSwipe(currentPos);
                else if (touch.phase == TouchPhase.Ended || touch.phase == TouchPhase.Canceled)
                    ended = true;
            }
#else
            currentPos = Input.mousePosition;
            
            if (Input.GetMouseButtonDown(0))
                StartSwipe(currentPos);
            else if (Input.GetMouseButtonUp(0))
                ended = true;
#endif

            if (!_isSwiping || !ended)
                return;
            
            var deltaX = currentPos.x - _startPosition.x;
            var deltaY = currentPos.y - _startPosition.y;

            if (Mathf.Abs(deltaX) >= _inputData.MinimumSwipeDistance)
            {
                Swipe?.Invoke(deltaX > 0
                    ? SwipeDirection.Right
                    : SwipeDirection.Left);
            }
            else if (Mathf.Abs(deltaY) >= _inputData.MinimumSwipeDistance)
            {
                Swipe?.Invoke(deltaY > 0
                    ? SwipeDirection.Top
                    : SwipeDirection.Down);
            }
                
            _isSwiping = false;
        }
        
        private void StartSwipe(Vector2 position)
        {
            _startPosition = position;
            _isSwiping = true;
        }
    }
}