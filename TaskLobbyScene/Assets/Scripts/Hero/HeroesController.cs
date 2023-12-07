using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class HeroesController
{
    [SerializeField] private GameObject[] _heroesPrefabs;
    
    private List<Hero> _heroesWithStats = new List<Hero>();

    public void InitializeHeroesStats()
    {

        if (_heroesPrefabs == null) return;
        
        for (var i = 0; i < _heroesPrefabs.Length; i++)
        {
            _heroesWithStats.Add(_heroesPrefabs[i].GetComponent<Hero>());

            _heroesWithStats[i].SetPrefabValue(_heroesPrefabs[i]);

        }

    }

    public Hero GetHero(int indexOfHero)
    {
        return _heroesWithStats[indexOfHero];
    }

    public int GetHeroesCount()
    {
        return _heroesWithStats.Count;
    }
    
    
}
