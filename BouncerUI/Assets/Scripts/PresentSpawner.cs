using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PresentSpawner : MonoBehaviour
{
    [SerializeField] private GameObject _presentPrefab;
    [SerializeField] private int _presentCount;
    
    [SerializeField] private float _minSpawnRange;
    [SerializeField] private float _maxSpawnRange;
    
    private readonly Dictionary<Color, int> SpawnedPresentsDictionary = new Dictionary<Color, int>();
    
    public void SpawnPresentsOnGameBoard(Color[] availableColors)
    {
        
        for (int i = 0; i < _presentCount; i++)
        {
            var present = Instantiate(_presentPrefab, GetRandomPosition(), Quaternion.identity).GetComponent<Present>();
            var randomColorIndex = Random.Range(0, availableColors.Length);
            var presentColor = present.SetColor(availableColors[randomColorIndex]);

            SpawnedPresentsDictionary.TryGetValue(presentColor, out var count);
            SpawnedPresentsDictionary[presentColor] = count + 1;

        }
    }

    public int GetPresentCountOfCurrentColor(Color color)
    {
        SpawnedPresentsDictionary.TryGetValue(color, out int presentCount);

        return presentCount;
    }

    public void DecreasePresentCount(Color keyColor)
    {
        SpawnedPresentsDictionary[keyColor]--;
    }
    
    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(_minSpawnRange, _maxSpawnRange), 0, Random.Range(_minSpawnRange, _maxSpawnRange));
    }
    
}
