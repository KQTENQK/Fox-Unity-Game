using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
using IJunior.TypedScenes;

[RequireComponent(typeof(Button))]
public class StartButton : MonoBehaviour
{
    [SerializeField] private float _fadeDuration;

    private Button _startButton;
    private TMP_Text _text;

    private void Awake()
    {
        _startButton = GetComponent<Button>();
        _text = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        _startButton.onClick.AddListener(OnButtonClick);
        _text.color = new Color(_text.color.r, _text.color.g, _text.color.b, 0);
        _text.DOFade(1, _fadeDuration);
    }

    private void OnDisable()
    {
        _startButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Game.Load();
    }
}
