using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[Serializable]
public class PlayerController
{
    
    public event Action OnHeroBought;
    
    private Wallet _wallet;

    public float GetGoldValue => _wallet.GoldAmount;
    public float GetGemsValue => _wallet.GemsAmount;
    
    private List<string> _boughtHeroesNames = new List<string>();


    public bool HaveEnoughGold(float price) => _wallet.GoldAmount >= price;

    public bool HaveEnoughGems(float price) => _wallet.GemsAmount >= price;

    public void AddHeroNameInBoughtList(string heroName)
    {
        if (!_boughtHeroesNames.Contains(heroName))
        {
            _boughtHeroesNames.Add(heroName);
        }
    }

    public bool IsHeroBought(string heroName)
    {
        return _boughtHeroesNames.Contains(heroName);
    }

    public void TryBuyHero(Hero hero)
    {
        if (!HaveEnoughGold(hero.Price)) return;
        
        _wallet.SpendGold(hero.Price);
        AddHeroNameInBoughtList(hero.Name);
        
        OnHeroBought?.Invoke();
    }
    
}
