using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UILobbySceneView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldValue;
    [SerializeField] private TextMeshProUGUI _gemesValue;
    [SerializeField] private TextMeshProUGUI _heroName;
    [SerializeField] private TextMeshProUGUI _heroLvl;
    [SerializeField] private TextMeshProUGUI _heroExperience;
    
    [SerializeField] private Slider _experianceValue;

    private void Awake()
    {
        SetHeroInformation(GameController.Instance.GetCurrentHero());
        SetHeroExperience();
        SetMoneyValue();
    }

    private void SetMoneyValue()
    {
        _goldValue.text = GameController.Instance.GetPlayersGoldValue().ToString("N0");
        _gemesValue.text = GameController.Instance.GetPlayersGemsValue().ToString("N0");
    }

    private void SetHeroInformation(Hero currentHero)
    {
        _heroName.text = currentHero.GetHeroesName();
        _heroLvl.text = currentHero.GetHeroLevel().ToString();
    }

    private void SetHeroExperience()
    {
        var hero = GameController.Instance.GetCurrentHero();
        
        _heroExperience.text = $"{hero.GetExperienceValue()}/{100}";
        _experianceValue.value = hero.GetExperienceValue();

    }
}
