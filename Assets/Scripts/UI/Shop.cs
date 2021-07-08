using System;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private List<Hero> _heroes;
    [SerializeField] private PlayerViewer _player;
    [SerializeField] private HeroView _template;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private Data _playerData;

    private List<HeroView> _views;
    private Hero _currentSelectedHero;

    public event Action<Hero> HeroSelected;
    public event Action<Hero> HeroSold;
    public event Action HeroDeselected;

    private void Start()
    {
        _views = new List<HeroView>();

        for (int i = 0; i < _heroes.Count; i++)
        {
            AddItem(_heroes[i]);
        }

        foreach (var item in _playerData.ctx.BuyedHeroesName)
        {
            foreach (var view in _views)
            {
                if (view.Hero.Name == item)
                {
                    view.Hero.Buy();
                    view.HidePrice();
                }
            }
        }
    }

    private void AddItem(Hero hero)
    {
        var view = Instantiate(_template, _itemContainer.transform);

        view.Render(hero);

        view.Selected += OnSelected;
        view.Selling += OnSelling;

        _views.Add(view);
    }

    private void OnSelected(Hero selectedHero)
    {
        Hero previousSelectedHero;

        if (_currentSelectedHero != null)
        {
            previousSelectedHero = _currentSelectedHero;
            HeroDeselected?.Invoke();
        }

        _currentSelectedHero = selectedHero;
        Destroy(_player.GetComponentInChildren<Hero>().gameObject);
        var hero = Instantiate(selectedHero, _player.transform);
        hero.transform.localRotation = Quaternion.Euler(0, 180, 0);

        if (selectedHero.IsBuyed)
            HeroSelected?.Invoke(selectedHero);
    }

    private void OnSelling(Hero hero, HeroView heroView)
    {
        TrySellHero(hero, heroView);
    }

    private void TrySellHero(Hero hero, HeroView heroView)
    {
        if (hero.Price <= _player.Money)
        {
            _player.BuyHero(hero);
            hero.Buy();
            heroView.Selling -= OnSelling;
            HeroSold?.Invoke(hero);
            HeroSelected?.Invoke(hero);
        }
    }

    private void OnDisable()
    {
        foreach (var view in _views)
        {
            view.Selected -= OnSelected;
        }
    }
}
