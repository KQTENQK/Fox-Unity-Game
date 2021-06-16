using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BestScoreRepresentor : MonoBehaviour
{
    [SerializeField] private Data _playerData;
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _scoreText;

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
        _scoreText.text = _playerData.ctx.BestScore.ToString();

        if (_player.Score > _playerData.ctx.BestScore)
            _scoreText.text = _player.Score.ToString();
    }
}
