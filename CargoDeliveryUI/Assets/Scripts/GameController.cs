using System;
using UnityEngine;

public class GameController : MonoBehaviour
{

    [SerializeField] private BoxController _boxController;
    [SerializeField] private LineDrawer _lineDrawer;
    [SerializeField] private SceneController _sceneController;

    private void Awake()
    {
        _boxController.OnPlayerLost += _sceneController.ShowDefeatScreen;
        _boxController.OnPlayerLost += _sceneController.MarkGameAsOvered;
        _boxController.OnPlayerWon += _sceneController.ShowVictoryScreen;

        _lineDrawer.OnMovingBox += _boxController.MoveBox;

    }

    private void OnDisable()
    {
        _boxController.OnPlayerLost -= _sceneController.ShowDefeatScreen;
        _boxController.OnPlayerWon -= _sceneController.ShowVictoryScreen;
        
        _lineDrawer.OnMovingBox -= _boxController.MoveBox;

    }
    
}