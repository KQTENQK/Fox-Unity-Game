using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DeathScreenAnimator : MonoBehaviour
{
    [SerializeField] private RectTransform _targetPoint;
    [SerializeField] private float _animationDuration;
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.Died -= OnDied;
    }

    private void OnDied()
    {
        float targetPositionX = _targetPoint.anchoredPosition.x;
        GetComponent<RectTransform>().DOAnchorPosX(targetPositionX, _animationDuration);
    }
}
