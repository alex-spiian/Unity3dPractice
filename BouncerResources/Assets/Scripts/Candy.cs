using System;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class Candy : MonoBehaviour
{
    [SerializeField] private ColorController _colorController;
    public Color CurrentColor;
    public bool IsCandyPickedUp;

    public void SetNewColor(Color newColor)
    {
        var childRenderer = transform.GetChild(0).GetComponent<Renderer>();
       
       childRenderer.materials[0].color = newColor;

    }
    

    public void SetNewPosition()
    {
        
        var randomPosition = new Vector3(Random.Range(-10, 10), 0.16f, Random.Range(-10, 10));
        transform.position = randomPosition;
      
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            SetNewPosition();
            SetNewColor(_colorController.GetRandomColor());
            IsCandyPickedUp = true;

        }
        
    }
    
}