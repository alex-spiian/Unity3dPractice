using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerController
{
    [SerializeField]
    private float _goldValue;

    [SerializeField]
    private float _gemsValue;

    private List<string> _boughtHeroesNames = new List<string>();
    
    public float GetGoldValue()
    {
        return _goldValue;
    }

    public float GetGemsValue()
    {
        return _gemsValue;
    }
    public void TakeAwayGoldAmount(float price)
    {
        _goldValue -= price;
    }
    
    public void TakeAwayGemsAmount(float price)
    {
        _gemsValue -= price;
    }
    

    public bool HaveEnoughGold(float price)
    {
        return _goldValue >= price;
    }
    
    public bool HaveEnoughGems(float price)
    {
        return _gemsValue >= price;
    }

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
    
}
