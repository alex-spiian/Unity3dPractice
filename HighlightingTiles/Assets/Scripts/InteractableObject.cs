using UnityEngine;
using UnityEngine.Serialization;

public class InteractableObject : MonoBehaviour
{
    [SerializeField]
    private Color _selectedStateColor;
    [SerializeField]
    private Color _standardStateColor;
    
    private Renderer _renderer;
    private Collider _collider;


    private void Awake()
    {
        _collider = transform.GetComponent<Collider>();
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (_collider.Raycast(ray, out var hitInfo, 30f))
        {
            if (hitInfo.transform.CompareTag("Interactable"))
            {
                SetColorOfSelectedState();
            }
            
        }
        else
        {
            SetColorOfStandardStater();
        }
        
    }

    private void SetColorOfSelectedState()
    {
        _renderer = transform.GetComponent<Renderer>();
        _renderer.material.color = _selectedStateColor;
    }

    private void SetColorOfStandardStater()
    {
        _renderer = transform.GetComponent<Renderer>();
        _renderer.material.color = _standardStateColor;

    }
}
