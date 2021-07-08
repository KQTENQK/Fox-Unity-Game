using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UFOMover : MonoBehaviour
{
    [SerializeField] private float _changeDirectionTimeOut;
    [SerializeField] private float _maxDirectionTimeOutSpred;
    [SerializeField] private float _xEdge;
    [SerializeField] private float _speed;

    private Vector3 _rightForward = new Vector3(1, 0, 1);
    private Vector3 _leftForward = new Vector3(-1, 0, 1);
    private Vector3 _rightBack = new Vector3(1, 0, -1);
    private Vector3 _leftBack = new Vector3(-1, 0, -1);
    private Vector3 _currentDirection;
    private float _timeOut;
    private float _elapsedTime;

    public float XEdge => _xEdge;

    private void Start()
    {
        _timeOut = _changeDirectionTimeOut + Random.Range(0, _maxDirectionTimeOutSpred);
        _elapsedTime = 0;
        _currentDirection = SelectDirection();
    }

    private void Update()
    {
        if (_elapsedTime >= _timeOut)
        {
            _currentDirection = SelectDirection();
            _elapsedTime = 0;
            _timeOut = _changeDirectionTimeOut + Random.Range(0, _maxDirectionTimeOutSpred);
        }

        _elapsedTime += Time.deltaTime;
    }

    private void FixedUpdate()
    {
        transform.Translate(_currentDirection * _speed);
        if (transform.position.x > _xEdge || transform.position.x < -_xEdge)
        {
            _currentDirection = new Vector3(-_currentDirection.x, _currentDirection.y, _currentDirection.z);
        }
    }

    private Vector3 SelectDirection()
    {
        int randomDirectionSelection = Random.Range(0, 8);

        switch (randomDirectionSelection)
        {
            case 0:
                return Vector3.left;
            case 1:
                return Vector3.right;
            case 2:
                return Vector3.forward;
            case 3:
                return Vector3.back;
            case 4:
                return _leftForward;
            case 5:
                return _rightForward;
            case 6:
                return _leftBack;
            case 7:
                return _rightBack;
            default:
                return Vector3.zero;
        }
    }
}
