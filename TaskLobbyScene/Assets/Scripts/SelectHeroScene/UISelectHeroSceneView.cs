using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UISelectHeroSceneView : MonoBehaviour
{
    [SerializeField] private Slider _healthValue;
    [SerializeField] private Slider  _attackValue;
    [SerializeField] private Slider _defenceValue;
    [SerializeField] private Slider _speedValue;
    
    [SerializeField] private TextMeshProUGUI _heroNameLabel;
    [SerializeField] private TextMeshProUGUI _heroWeaponLabel;
    [SerializeField] private TextMeshProUGUI _heroPriceLabel;
    [SerializeField] private TextMeshProUGUI _goldValueLabel;
    [SerializeField] private TextMeshProUGUI _gemesValueLabel;
    [SerializeField] private TextMeshProUGUI _heroExperienceLabel;
    [SerializeField] private TextMeshProUGUI _heroLevelLabel;
    
    [SerializeField] private Button _buyHeroButton;
    [SerializeField] private Button _selectHeroButton;

    public void SetHeroName(string name)
    {
        _heroNameLabel.text = name;
    }
    
    public void SetHeroWeapon(string weapon)
    {
        _heroWeaponLabel.text = weapon;
    }

    public void SetHeroLevel(float level)
    {
        _heroLevelLabel.text = level.ToString();
    }
    
    public void SetHealthValue(float healthValue)
    {
        _healthValue.value = healthValue;
    }
    
    public void SetAttackValue(float attackValue)
    {
        _attackValue.value = attackValue;
    }
    
    public void SetDefenceValue(float defenceValue)
    {
        _defenceValue.value = defenceValue;
    }
    
    public void SetSpeedValue(float speedValue)
    {
        _speedValue.value = speedValue;
    }

    public void SetHeroesPrice(string priceValue)
    {
        _heroPriceLabel.text = priceValue;
    }

    public void ChangeStateOfButtonsBuyAndSelect(bool canSelectHero)
    {
        if (!canSelectHero)
        {
            _buyHeroButton.gameObject.SetActive(true);
            _selectHeroButton.interactable = false;
        }
        else
        {
            _buyHeroButton.gameObject.SetActive(false);
            _selectHeroButton.interactable = true;
        }
    }

    public void UpdateMoneyValue()
    {
        _goldValueLabel.text = GameController.Instance.GetPlayersGoldValue().ToString("N0");
        _gemesValueLabel.text = GameController.Instance.GetPlayersGemsValue().ToString("N0");
    }
    
    public void SetHeroExperience(Hero hero)
    {
        _heroExperienceLabel.text = $"{hero.GetExperienceValue()}/{100}";
    }
    
}
