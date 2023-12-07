using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbySceneController : MonoBehaviour
{
    [SerializeField]
    private Vector3 _spawnPoint = new Vector3(0f, -0.92f, 0f);

    private void Awake()
    {
        InstantiateHero();
    }

    private void InstantiateHero()
    {
        var currentHeroPrefab = GameController.Instance.GetCurrentHero().GetPrefabValue();
        
        var hero = Instantiate(currentHeroPrefab);

        hero.transform.position = _spawnPoint;

    }

    public void ChangeHero()
    {
        GameController.Instance.LoadSelectHeroScene();

    }

    
}
