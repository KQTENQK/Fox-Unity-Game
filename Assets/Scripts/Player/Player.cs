using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float _scoreAdditionTime;

    private Hero _hero;
    private bool _died = false;
    private int _money;
    private int _score;

    public int Money => _money;
    public int Score => _score;

    public event Action BalanceChanged;
    public event Action Died;
    public event Action<int> ScoreChanged;

    private void OnDisable()
    {
        _hero.Died -= OnDied;
    }

    private void Start()
    {
        _money = GetComponent<Data>().ctx.Balance;
        _hero = GetComponentInChildren<Hero>();
        _hero.Died += OnDied;
        StartCoroutine(AddScore());
    }

    private IEnumerator AddScore()
    {
        while (true)
        {
            if (_died)
                break;

            _score++;
            ScoreChanged.Invoke(_score);
            yield return new WaitForSeconds(_scoreAdditionTime);
        }
    }

    public void CollectSphere()
    {
        _money++;
        BalanceChanged?.Invoke();
    }

    private void OnDied()
    {
        _died = true;
        gameObject.GetComponent<PlayerMover>().Stop();
        Died?.Invoke();
    }
}
