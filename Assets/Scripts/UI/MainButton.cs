using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;

public class MainButton : MonoBehaviour
{
    [SerializeField] private Button _mainButton;

    private void OnEnable()
    {
        _mainButton.onClick.AddListener(OnButtonClick);
    }

    private void OnDisable()
    {
        _mainButton.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick()
    {
        Start.Load(UnityEngine.SceneManagement.LoadSceneMode.Single);
    }
}
