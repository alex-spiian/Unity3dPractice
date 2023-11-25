using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Snowman _snowman;
    [SerializeField] private Candy _candy;
    [SerializeField] private PresentSpawner _presentSpawner;
    [SerializeField] private ColorController _colorController;
    
    private Vector3 _destination;
    private void Awake()
    {
        _presentSpawner.SpawnPresentsOnGameBoard();
        _snowman.SetNewColor(_colorController.GetRandomColor());
        _candy.SetNewPosition();
        _candy.SetNewColor(_colorController.GetRandomColor());
    }

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            GetDestination();
            _snowman.MoveSnowmanByForce(_destination);
        }
    }

    private void Update()
    {

        if (_candy.IsCandyPickedUp)
        {
            
            var randomColor = _colorController.GetRandomColor();
            _candy.SetNewColor(randomColor);

            _candy.SetNewPosition();
            _snowman.SetNewColor(_candy.CurrentColor);
            _candy.CurrentColor = randomColor;

            _candy.IsCandyPickedUp = false;
        }
    }

    private void GetDestination()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hitInfo))
        {
            _destination = hitInfo.point;
            Debug.Log(_destination);

        }
    }

}
