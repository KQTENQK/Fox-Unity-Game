using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerViewer : MonoBehaviour
{
    [SerializeField] private Shop _shop;
    [SerializeField] private List<Hero> _heroes;
    [SerializeField] private Data _playerData;

    private int _money;
    private Hero _selectedHero;

    public int Money => _money;
    public Hero SelectedHero => _selectedHero;

    public event Action BalanceChanged;

    private void OnEnable()
    {
        _shop.HeroSelected += OnHeroSelected;
    }

    private void OnDisable()
    {
        _shop.HeroSelected -= OnHeroSelected;
    }

    private void Start()
    {
        foreach (var hero in _heroes)
        {
            if (hero.Name == _playerData.ctx.SelectedHero)
                _selectedHero = hero;
        }
        _money = _playerData.ctx.Balance;

        var instantiatedHero = Instantiate(_selectedHero, transform);
        instantiatedHero.transform.localRotation = Quaternion.Euler(0, 180, 0);
    }

    public void AddMoney(int money)
    {
        _money += money;
        BalanceChanged?.Invoke();
    }

    public void BuyHero(Hero hero)
    {
        _money -= hero.Price;
        BalanceChanged?.Invoke();
    }

    private void OnHeroSelected(Hero hero)
    {
        _selectedHero = hero;
    }
}
