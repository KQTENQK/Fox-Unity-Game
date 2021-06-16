using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;
using System;

public class HeroView : MonoBehaviour
{
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _previewButton;
    [SerializeField] private Button _sellButton;
    [SerializeField] private GameObject _sphere;
    
    private Hero _hero;
    private Shop _shop;

    public Hero Hero => _hero;


    public event Action<Hero> Selected;
    public event Action<Hero, HeroView> Selling;

    private void OnEnable()
    {
        _previewButton.onClick.AddListener(OnPreviewButtonClick);
        _shop = FindObjectOfType<Shop>();
        _shop.HeroDeselected += OnHeroDeselected;
    }

    private void OnDisable()
    {
        _previewButton.onClick.RemoveListener(OnPreviewButtonClick);
        _shop.HeroDeselected -= OnHeroDeselected;
    }

    public void Render(Hero hero)
    {
        _hero = hero;

        _price.text = _hero.Price.ToString();
        _icon.sprite = _hero.Icon;
    }

    public void HidePrice()
    {
        _price.gameObject.SetActive(false);
        _sphere.SetActive(false);
    }

    private void OnPreviewButtonClick()
    {
        Selected?.Invoke(_hero);

        if (!_hero.IsBuyed)
        {
            _sellButton.gameObject.SetActive(true);
            _sellButton.onClick.AddListener(OnSellButtonClick);
        }
    }

    private void OnSellButtonClick()
    {
        Selling?.Invoke(_hero, this);
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
        _sellButton.gameObject.SetActive(false);
    }

    private void OnHeroDeselected()
    {
        _sellButton.onClick.RemoveListener(OnSellButtonClick);
        _sellButton.gameObject.SetActive(false);
    }
}
