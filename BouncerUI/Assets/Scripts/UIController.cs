using System;
using System.Collections.Generic;
using DefaultNamespace;
using TMPro;
using UnityEngine;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countRedPresentsTextLabel;
    [SerializeField] private TextMeshProUGUI _countGreenPresentsTextLabel;
    [SerializeField] private TextMeshProUGUI _countBluePresentsTextLabel;
    [SerializeField] private TextMeshProUGUI _movementCountTextLabel;
    
    public void UpdatePresentsCount(string colorName, int presentCount)
    {

        switch (colorName)
        {
            case GlobalConstants.RED_COLOR_NAME:
                _countRedPresentsTextLabel.text = presentCount.ToString();
                break;
            
            case GlobalConstants.GREEN_COLOR_NAME:
                _countGreenPresentsTextLabel.text = presentCount.ToString();
                break;
            
            case GlobalConstants.BLUE_COLOR_NAME:
                _countBluePresentsTextLabel.text = presentCount.ToString();
                break;
            
        }
    }

    public void UpdateMovementCount(int movementCount)
    {
        _movementCountTextLabel.text = movementCount.ToString();
    }
}