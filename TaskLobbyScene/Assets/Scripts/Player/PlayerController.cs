using System;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

[Serializable]
public class PlayerController
{
    
    public event Action OnHeroBought;
    
    public Wallet Wallet;

    public float GetGoldValue => Wallet.GoldAmount;
    public float GetGemsValue => Wallet.GemsAmount;
    
    private List<string> _boughtHeroesNames = new List<string>();


    public bool HaveEnoughGold(float price) => Wallet.GoldAmount >= price;

    public bool HaveEnoughGems(float price) => Wallet.GemsAmount >= price;

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
        
        Wallet.SpendGold(hero.Price);
        AddHeroNameInBoughtList(hero.Name);
        
        OnHeroBought?.Invoke();
    }
    
}
