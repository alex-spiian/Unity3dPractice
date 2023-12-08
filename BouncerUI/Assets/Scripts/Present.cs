using UnityEngine;

public class Present : MonoBehaviour
{
    public Color Color { get; private set; }

    public Color SetColor(Color randomColor)
    {
        var childRenderer = transform.GetChild(0).GetComponent<Renderer>();
        childRenderer.materials[1].color = randomColor;
        Color = randomColor;

        return randomColor;
    }
    
}
