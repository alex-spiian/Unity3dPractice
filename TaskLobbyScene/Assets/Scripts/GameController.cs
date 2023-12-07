using DefaultNamespace;
using DefaultNamespace.SceneController;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public int CurrentHeroIndex;
    public int HeroesCount;
    
    [SerializeField]
    private HeroesController _heroesController;
    
    [SerializeField]
    private PlayerController _playerController;

    [SerializeField]
    private SceneController _sceneController;
    
    private static GameController _instance;
    public static GameController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<GameController>();
                
                if (_instance == null)
                {
                    var singleton = new GameObject("GameController");
                    _instance = singleton.AddComponent<GameController>();
                }

                if (_instance != null)
                {
                    DontDestroyOnLoad(_instance);
                }
            }
            
            return _instance;
        }
    }
    
    private void Awake()
    {
        _heroesController.InitializeHeroesStats();
        _playerController.AddHeroNameInBoughtList(GlobalConstants.FIRST_FREE_HERO_NAME);
        
        HeroesCount = _heroesController.GetHeroesCount();
        
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        
    }

    public float GetPlayersGoldValue()
    {
        return _playerController.GetGoldValue();
    }
    
    public float GetPlayersGemsValue()
    {
        return _playerController.GetGemsValue();
    }

    public bool HasPlayerEnoughGold(float price)
    {
        return _playerController.HaveEnoughGold(price);
    }
    
    public bool HasPlayerEnoughGems(float price)
    {
        return _playerController.HaveEnoughGems(price);
    }

    public void TakeAwayGoldAmountInPlayer(float price)
    {
        _playerController.TakeAwayGoldAmount(price);
    }
    
    public void TakeAwayGemsAmountInPlayer(float price)
    {
        _playerController.TakeAwayGemsAmount(price);
    }

    public Hero GetCurrentHero()
    {
        return _heroesController.GetHero(CurrentHeroIndex);
    }
    
    
    public void AddHeroNameInBoughtList(string heroName)
    {
        _playerController.AddHeroNameInBoughtList(heroName);
    }

    public bool IsHeroBought(string heroName)
    {
        return _playerController.IsHeroBought(heroName);
    }

    public void LoadLobbyScene()
    {
        _sceneController.LoadLobbyScene();
    }

    public void LoadSelectHeroScene()
    {
        _sceneController.LoadSelectHeroScene();
    }
    
    
}