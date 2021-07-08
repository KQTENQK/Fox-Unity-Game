using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class RestartButton : MonoBehaviour
{
    [SerializeField] private Button _restartButton;

    private void OnEnable()
    {
        _restartButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _restartButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Game.Load();
    }
}
