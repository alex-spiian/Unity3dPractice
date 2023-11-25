using UnityEngine;

public class Present : MonoBehaviour
{
    private ColorController _colorController;
    public Color Color;
    
    private void Awake()
    {
        _colorController = FindObjectOfType<ColorController>();
        
        var childRenderer = transform.GetChild(0).GetComponent<Renderer>();
        var randomColor = _colorController.GetRandomColor();
        childRenderer.materials[1].color = randomColor;
        Color = randomColor;
    }
    
}