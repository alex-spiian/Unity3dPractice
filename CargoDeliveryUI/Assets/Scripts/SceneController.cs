using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour

{
    [SerializeField] private Canvas _victoryScreenCanvas;
    [SerializeField] private Canvas _defeasScreenCanvas;


    private bool _isGameOvered;
    public void ResetFirstLevel()
    {
        SceneManager.LoadScene(GlobalConstants.GAME_SCENE_NAME);
    }

    public void ShowVictoryScreen()
    {
        if (!_defeasScreenCanvas.isActiveAndEnabled && !_isGameOvered)
        {
            _victoryScreenCanvas.gameObject.SetActive(true);
        }
        
    }
    
    public void HideVictoryScreen()
    {
        _victoryScreenCanvas.enabled = false;
    }

    public void ShowDefeatScreen()
    {
        if (!_victoryScreenCanvas.isActiveAndEnabled && _isGameOvered)
        {
            _defeasScreenCanvas.gameObject.SetActive(true);
        }
 
    }
    
    public void HideDefeatScreen()
    {
        _defeasScreenCanvas.enabled = false;
    }
    
    public void MarkGameAsOvered()
    {
        _isGameOvered = true;
    }
        
}