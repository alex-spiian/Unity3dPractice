using UnityEngine;
using Random = UnityEngine.Random;

public class ColorController : MonoBehaviour
{
    [SerializeField] private Color[] _availableColors;
    
    public Color GetRandomColor()
    
    {
        return _availableColors[Random.Range(0, _availableColors.Length)];
        
    }
    
}