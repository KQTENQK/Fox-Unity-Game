using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class FoxAnimator : MonoBehaviour
{
    private SwipeDetecter _playerInputHandler;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _playerInputHandler = FindObjectOfType<SwipeDetecter>();
    }

    private void OnEnable()
    {
        _playerInputHandler.Swiped += OnSwiped;
    }

    private void OnDisable()
    {
        _playerInputHandler.Swiped -= OnSwiped;
    }

    private void OnSwiped(Vector2 direction)
    {
        if (direction == Vector2.left)
            TurnLeft();
        else if (direction == Vector2.right)
            TurnRight();
    }

    private void TurnLeft()
    {
        _animator.SetTrigger("TurnLeft");
    }

    private void TurnRight()
    {
        _animator.SetTrigger("TurnRight");
    }
}
