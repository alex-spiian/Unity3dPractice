using UnityEngine;

public class Hero : MonoBehaviour
{   
    [SerializeField] private string _name;
    [SerializeField] private string _weapon;
    
    [SerializeField] private float _health;
    [SerializeField] private float _attack;
    [SerializeField] private float _defence;
    [SerializeField] private float _speed;
    [SerializeField] private float _price;
    [SerializeField] private float _currentValueOfExperience;
    
    [SerializeField] private int _level;
    
    private GameObject _heroPrefab;

    public void SetPrefabValue(GameObject prefab)
    {
        _heroPrefab = prefab;
    }
    
    public GameObject GetPrefabValue()
    {
        return _heroPrefab;
    }
    public float GetHealthValue()
    {
        return _health;
    }
    
    public float GetAttackValue()
    {
        return _attack;
    }
    public float GetDefenceValue()
    {
        return _defence;
    }
    public float GetSpeedValue()
    {
        return _speed;
    }

    public float GetHeroesPrice()
    {
        return _price;
    }
    
    public string GetHeroesName()
    {
        return _name;
    }

    public float GetHeroLevel()
    {
        return _level;
    }

    public string GetHeroWeapon()
    {
        return _weapon;
    }

    public float GetExperienceValue()
    {
        return _currentValueOfExperience;
    }

}
