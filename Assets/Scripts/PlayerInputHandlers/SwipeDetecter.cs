using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class SwipeDetecter : MonoBehaviour
{
    [SerializeField] private float _minSwipeDistance;
    [SerializeField] private float _maxPassedTime;
    [SerializeField, Range(0, 1)] private float _swipeDeviation;

    private PlayerInput _playerInput;
    private Vector2 _startPosition;
    private Vector2 _endPosition;
    private float _startTime;
    private float _endTime;

    public event Action<Vector2> Swiped;

    private void OnEnable()
    {
        _playerInput = new PlayerInput();
        _playerInput.Enable();
        _playerInput.Main.Swipe.started += ctx => OnSwipeStarted(ctx);
        _playerInput.Main.Swipe.canceled += ctx => OnSwipeEnded(ctx);
    }

    private void OnDisable()
    {
        _playerInput.Main.Swipe.started -= ctx => OnSwipeStarted(ctx);
        _playerInput.Main.Swipe.canceled -= ctx => OnSwipeEnded(ctx);
        _playerInput.Disable();
    }

    private void OnSwipeStarted(InputAction.CallbackContext context)
    {
        _startPosition = _playerInput.Main.SwipePosition.ReadValue<Vector2>();
        _startTime = (float)context.startTime;
    }

    private void OnSwipeEnded(InputAction.CallbackContext context)
    {
        _endPosition = _playerInput.Main.SwipePosition.ReadValue<Vector2>();
        _endTime = (float)context.time;
        Detect(_startPosition, _endPosition, _startTime, _endTime);
    }

    private void Detect(Vector2 startPosition, Vector2 endPosition, float startTime, float endTime)
    {
        if (Vector2.Distance(startPosition, endPosition) >= _minSwipeDistance && (endTime - startTime) <= _maxPassedTime)
        {
            Vector2 direction = (endPosition - startPosition).normalized;

            if (Vector2.Dot(Vector2.left, direction) > _swipeDeviation)
                Swiped?.Invoke(Vector2.left);
            else if (Vector2.Dot(Vector2.right, direction) > _swipeDeviation)
                Swiped?.Invoke(Vector2.right);
            else if (Vector2.Dot(Vector2.up, direction) > _swipeDeviation)
                Swiped?.Invoke(Vector2.up);
        }
    }
}
