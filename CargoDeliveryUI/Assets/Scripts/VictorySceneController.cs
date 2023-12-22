using System;
using DefaultNamespace;
using UnityEngine;
public class VictorySceneController : MonoBehaviour
{
    [SerializeField] private StarController _starController;
        
    private void OnEnable()
    {
        _starController.StartStarsFall();
        
    }
}