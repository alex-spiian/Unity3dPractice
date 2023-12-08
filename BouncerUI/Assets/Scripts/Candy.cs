using DefaultNamespace;
using UnityEngine;
using Random = UnityEngine.Random;

public class Candy : MonoBehaviour
{
    public bool IsCandyPickedUp;

    [SerializeField] private float _minSpawnRange;
    [SerializeField] private float _maxSpawnRange;
    
    private Color _currentColor;
    private Renderer _childRenderer;

    private void Awake()
    {
        _childRenderer = transform.GetChild(0).GetComponent<Renderer>();
    }

    public void SetNewColor(Color newColor)
    {
        _childRenderer.materials[0].color = newColor;
        _currentColor = newColor;

    }

    public Color GetCurrentColor()
    {
        return _currentColor;
    }
    

    public void SetNewPosition()
    {
        var randomPosition = new Vector3(Random.Range(_minSpawnRange, _maxSpawnRange), 0, Random.Range(_minSpawnRange, _maxSpawnRange));
        transform.position = randomPosition;
    }

  
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag(GlobalConstants.PLAYER_TAG))
        {
            IsCandyPickedUp = true;
        }
    }

}