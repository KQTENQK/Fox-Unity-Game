using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ShopAnimation : MonoBehaviour
{
    [SerializeField] private Button _shopButton;
    [SerializeField] private RectTransform _panelTransform;
    [SerializeField] private float _animationDuration;
    [SerializeField] private Button _startButton;

    private RectTransform _buttonTransform;
    private bool _moveLeft = true;

    private void OnEnable()
    {
        _shopButton.onClick.AddListener(Move);
    }

    private void OnDisable()
    {
        _shopButton.onClick.RemoveListener(Move);
    }

    private void Start()
    {
        _buttonTransform = _shopButton.GetComponent<RectTransform>();
    }

    private void Move()
    {
        if (_moveLeft)
            MoveLeft();
        else
            MoveRight();

        _moveLeft = !_moveLeft;
        _startButton.gameObject.SetActive(_moveLeft);
    }

    private void MoveLeft()
    {
        float targetPositionX = _buttonTransform.anchoredPosition.x;
        _panelTransform.DOAnchorPosX(targetPositionX, _animationDuration);
    }

    private void MoveRight()
    {
        float targetPositionX = 0;
        _panelTransform.DOAnchorPosX(targetPositionX, _animationDuration);
    }
}
