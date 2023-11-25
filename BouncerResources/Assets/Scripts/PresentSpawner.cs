using UnityEngine;
using Random = UnityEngine.Random;

public class PresentSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _presentPrefab;
    [SerializeField] private int _presentCount;
    
    public void SpawnPresentsOnGameBoard()
    {
        
        for (int i = 0; i < _presentCount; i++)
        {
            Instantiate(_presentPrefab, GetRandomPosition(), Quaternion.identity);
        }
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10));
    }
}
