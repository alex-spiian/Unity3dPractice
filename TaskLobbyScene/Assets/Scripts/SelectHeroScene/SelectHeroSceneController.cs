using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectHeroSceneController : MonoBehaviour
{
    [SerializeField]
    private UISelectHeroSceneView _uiSelectHeroSceneView;
    
    [SerializeField]
    private Vector3 _spawnPoint = new Vector3(0f, -2.2f, 0f);
    
    private GameObject _currentHero;

    private void Awake()
    {
        var currentHeroPrefab = GameController.Instance.GetCurrentHero().GetPrefabValue();
        
        _currentHero = Instantiate(currentHeroPrefab);
        _currentHero.transform.position = _spawnPoint;
        
        UpdateHeroStats();
        UpdateHeroInformation();
        SetButtonsBuyAndSelectInRightState();
        
        _uiSelectHeroSceneView.UpdateMoneyValue();

    }

    public void NextHero()
    {
        var availableHeroesCount = GameController.Instance.HeroesCount;
        
        if (GameController.Instance.CurrentHeroIndex + 1 >= availableHeroesCount) return;
        
        Destroy(_currentHero);
        
        GameController.Instance.CurrentHeroIndex++;
        var currentHeroPrefab = GameController.Instance.GetCurrentHero().GetPrefabValue();
        
        _currentHero = Instantiate(currentHeroPrefab);
        _currentHero.transform.position = _spawnPoint;
        
        UpdateHeroStats();
        UpdateHeroInformation();
        SetButtonsBuyAndSelectInRightState();

    }

    public void PreviousHero()
    {
        if (GameController.Instance.CurrentHeroIndex <= 0) return;
        
        Destroy(_currentHero);

        GameController.Instance.CurrentHeroIndex--;
        var currentHeroPrefab = GameController.Instance.GetCurrentHero().GetPrefabValue();
        
        _currentHero = Instantiate(currentHeroPrefab);
        _currentHero.transform.position = _spawnPoint;

        UpdateHeroStats();
        UpdateHeroInformation();
        SetButtonsBuyAndSelectInRightState();
    }

    private void SetButtonsBuyAndSelectInRightState()
    {
        if (GameController.Instance.IsHeroBought(GameController.Instance.GetCurrentHero().GetHeroesName()))
        {
            _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect(true);
        }
        else
        {
            _uiSelectHeroSceneView.ChangeStateOfButtonsBuyAndSelect(false);
        }
    }

    private void UpdateHeroStats()
    {
        var currentHero = GameController.Instance.GetCurrentHero();
        
        _uiSelectHeroSceneView.SetAttackValue(currentHero.GetAttackValue());
        _uiSelectHeroSceneView.SetDefenceValue(currentHero.GetDefenceValue());
        _uiSelectHeroSceneView.SetHealthValue(currentHero.GetHealthValue());
        _uiSelectHeroSceneView.SetSpeedValue(currentHero.GetSpeedValue());
        _uiSelectHeroSceneView.SetHeroesPrice(currentHero.GetHeroesPrice().ToString());
    }

    private void UpdateHeroInformation()
    {
        var currentHero = GameController.Instance.GetCurrentHero();

        _uiSelectHeroSceneView.SetHeroName(currentHero.GetHeroesName());
        _uiSelectHeroSceneView.SetHeroLevel(currentHero.GetHeroLevel());
        _uiSelectHeroSceneView.SetHeroWeapon(currentHero.GetHeroWeapon());
        _uiSelectHeroSceneView.SetHeroExperience(currentHero);
    }
    
    public void BuyHero()
    {
        var currentHero = GameController.Instance.GetCurrentHero();
        
        if (GameController.Instance.HasPlayerEnoughGold(currentHero.GetHeroesPrice()))
        {
            GameController.Instance.TakeAwayGoldAmountInPlayer(currentHero.GetHeroesPrice());
            GameController.Instance.AddHeroNameInBoughtList(currentHero.GetHeroesName());
            
            SetButtonsBuyAndSelectInRightState();
            
            _uiSelectHeroSceneView.UpdateMoneyValue();
        }
        
    }
    
    public void SelectHero()
    {
        GameController.Instance.LoadLobbyScene();
    }

    public void BackToLobbyScene()
    {
        GameController.Instance.LoadLobbyScene();
    }

  
}
