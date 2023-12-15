using DefaultNamespace;
using DefaultNamespace.SceneController;
using UnityEngine;

public class LobbySceneController : MonoBehaviour
{
    [SerializeField] private Vector3 _spawnPoint;
    
    [SerializeField] private UILobbySceneView _uiLobbySceneView;
    [SerializeField] private MoneyView _moneyView;
    
    [SerializeField] private SceneController _sceneController;
    
    private void Awake()
    {
        
        InstantiateHero();
        _moneyView.UpdateMoneyView();
        _uiLobbySceneView.UpdateHeroInformation(GameController.Instance.GetCurrentHero);
        
    }

    private void InstantiateHero()
    {

        var currentHero = GameController.Instance.GetCurrentHero;

        Instantiate(currentHero.HeroPrefab).transform.position = _spawnPoint;


    }

    public void ChangeHero()
    {
        _sceneController.LoadSelectHeroScene();
    }
    
    
}
