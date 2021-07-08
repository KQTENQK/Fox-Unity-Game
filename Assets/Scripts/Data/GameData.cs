using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class GameData : Data
{
    [SerializeField] private Player _player;

    private void OnEnable()
    {
        _player.BalanceChanged += OnBalaceChanged;
        _player.Died += OnDied;
    }

    private void OnDisable()
    {
        _player.BalanceChanged -= OnBalaceChanged;
        _player.Died += OnDied;
    }

    private void OnBalaceChanged()
    {
        ctx.Balance = _player.Money;
        File.WriteAllText(PathToJson, JsonUtility.ToJson(ctx));
    }

    private void OnDied()
    {
        if (_player.Score > ctx.BestScore)
        {
            ctx.BestScore = _player.Score;
            File.WriteAllText(PathToJson, JsonUtility.ToJson(ctx));
        }
    }
}
