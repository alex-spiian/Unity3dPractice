using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class GameController : MonoBehaviour
{
    [SerializeField] private GameObject _candyPrefab;
    [SerializeField] private GameObject _snowmanPrefabd;
    [SerializeField] private Camera _mainCamera;
    
    [SerializeField] private PresentSpawner _presentSpawner;
    [SerializeField] private ColorController _colorController;
    [SerializeField] private UIController _uiController;

    private Candy _candy;
    private Snowman _snowman;
    private void Awake()
    {
        _presentSpawner.SpawnPresentsOnGameBoard(_colorController.AvailableColors);
        SpawnSnowman();
        SpawnCandy();
        _colorController.CreateDictionaryColorName();
        UpdatePresentCount();            
    }
    

    private void Update()
    {
        RunGame();
        
    }

    private void RunGame()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _snowman.MoveSnowmanByForce(GetDestination());
            _uiController.UpdateMovementCount(_snowman.MovementCount);
        }
        
        if (_candy.IsCandyPickedUp)
        {
            var randomColor = _colorController.GetRandomColor();

            _snowman.SetNewColor(_candy.GetCurrentColor());
            
            _candy.SetNewColor(randomColor);
            _candy.SetNewPosition();
            _candy.IsCandyPickedUp = false;
        }

        if (_snowman.WasPresentPickedUp)
        {
            _presentSpawner.DecreasePresentCount(_snowman.PickedUpPresentColor);
            UpdatePresentCount();
            _snowman.WasPresentPickedUp = false;
        }
    }
    
    private Vector3 GetDestination()
    {
        var ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out var hitInfo);
        
        return hitInfo.point;

    }

    private void SpawnSnowman()
    {
        _snowman = Instantiate(_snowmanPrefabd).GetComponent<Snowman>();
    }
    
    private void SpawnCandy()
    {
        var randomColor = _colorController.GetRandomColor();
        _candy = Instantiate(_candyPrefab).GetComponent<Candy>();
        _candy.SetNewColor(randomColor);
        _candy.SetNewPosition();
    }

    private void UpdatePresentCount()
    {
        foreach (var currentColor in _colorController.AvailableColors)
        {
            var currentColorName = _colorController.GetColorName(currentColor);
            var presentsCountOfCurrentColor = _presentSpawner.GetPresentCountOfCurrentColor(currentColor);
            
            _uiController.UpdatePresentsCount(currentColorName, presentsCountOfCurrentColor);
        }
    }

}

