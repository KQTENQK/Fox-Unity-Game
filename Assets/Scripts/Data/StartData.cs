using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StartData : Data
{
    [SerializeField] private Shop _shop;
    [SerializeField] private PlayerViewer _player;

    private void OnEnable()
    {
        _shop.HeroSold += OnHeroSold;
        _shop.HeroSelected += OnHeroSelected;
        _player.BalanceChanged += OnBalancehanged;
    }

    private void OnDisable()
    {
        _shop.HeroSold -= OnHeroSold;
        _shop.HeroSelected -= OnHeroSelected;
        _player.BalanceChanged -= OnBalancehanged;
    }

    private void OnHeroSold(Hero hero)
    {
        ctx.BuyedHeroesName.Add(hero.name);
        Write(ctx);
    }

    private void OnHeroSelected(Hero hero)
    {
        ctx.SelectedHero = hero.Name;
        Write(ctx);
    }

    private void OnBalancehanged()
    {
        ctx.Balance = _player.Money;
        Write(ctx);
    }
}
