using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Balance : MonoBehaviour
{
    [SerializeField] private PlayerViewer _player;
    [SerializeField] private TMP_Text _balance;

    private void OnEnable()
    {
        _player.BalanceChanged += OnBalanceChanged;
    }

    private void OnDisable()
    {
        _player.BalanceChanged -= OnBalanceChanged;
    }

    private void Start()
    {
        _balance.text = _player.Money.ToString();
    }

    private void OnBalanceChanged()
    {
        _balance.text = _player.Money.ToString();
    }
}
