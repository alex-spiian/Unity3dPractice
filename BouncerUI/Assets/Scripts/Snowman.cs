using DefaultNamespace;
using UnityEngine;

public class Snowman : MonoBehaviour
{
    public bool WasPresentPickedUp;
    public Color PickedUpPresentColor { get; private set; }
    public int MovementCount { get; private set; }

    [SerializeField]  private float _forceValue;
    private Color _currentColor;

    private Rigidbody _rigidBody;
    private Renderer _renderer;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody>();
        _renderer = GetComponent<Renderer>();
    }

    public void SetNewColor(Color newColor)
    {
        _renderer.materials[0].color = newColor;
        _currentColor = newColor;
    }
    public void MoveSnowmanByForce(Vector3 direction)
    {
        _rigidBody.velocity = Vector3.zero;
        _rigidBody.AddForce(new Vector3(direction.x, 0, direction.z).normalized * _forceValue);
        MovementCount++;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (!collision.transform.CompareTag(GlobalConstants.PRASENT_TAG)) return;
        
        var present = collision.gameObject.GetComponent<Present>();
        if (_currentColor.Equals(present.Color))
        {
            PickedUpPresentColor = present.Color;
            Destroy(collision.gameObject);
            WasPresentPickedUp = true;
        }
    }
    
}
