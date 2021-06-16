using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;


public class PlayerMover : MonoBehaviour
{
    private const float SpeedFactor = 0.01f;

    [SerializeField] private float _speed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private float _speedChangeDuration;
    [SerializeField] private float _xSwipeWayStep;
    [SerializeField] private float _xSwipeLimit;
    [SerializeField] private float _turningTime;
    [SerializeField] private SwipeDetecter _swipeDetecter;

    private int _swipeCount;
    private float _startSpeed;
    private Vector3 _moveDirection;
    private bool _stopIncreasingSpeed;

    private void OnEnable()
    {
        _swipeDetecter.Swiped += OnSwiped;
        _swipeCount = 0;
    }

    private void OnDisable()
    {
        _swipeDetecter.Swiped -= OnSwiped;
    }

    private void Start()
    {
        _startSpeed = _speed;

        StartCoroutine(IncreaseSpeed());
    }

    private void FixedUpdate()
    {
        Move(_moveDirection);
    }

    public void Stop()
    {
        _stopIncreasingSpeed = true;
        _moveDirection = Vector3.zero;
    }

    private void Move(Vector3 moveDirection)
    {
        transform.Translate(moveDirection);
    }

    private void OnSwiped(Vector2 direction)
    {
        if ((_swipeCount != _xSwipeLimit && _swipeCount != -_xSwipeLimit) ||
            (_swipeCount == _xSwipeLimit && direction.x == Vector2.left.x) ||
            (_swipeCount == -_xSwipeLimit && direction.x == Vector2.right.x))
        {
            StartCoroutine(Turn(direction));
            _swipeCount += (int)direction.x;
        }
    }

    private IEnumerator IncreaseSpeed()
    {
        while (!_stopIncreasingSpeed)
        {
            if (_speed <= _maxSpeed)
                _speed++;
            else
                _speed = _startSpeed;

            _moveDirection = transform.forward * _speed * SpeedFactor;

            yield return new WaitForSeconds(_speedChangeDuration);
        }
    }

    private IEnumerator Turn(Vector2 direction)
    {
        float elapsedTime = 0;
        while (elapsedTime < _turningTime)
        {
            elapsedTime += Time.fixedDeltaTime;
            transform.position = new Vector3(transform.position.x + (1 / _turningTime) * _xSwipeWayStep * direction.x * Time.fixedDeltaTime, transform.position.y, transform.position.z);
            yield return new WaitForFixedUpdate();
        }
    }
}
