using UnityEngine;

public class Snowman : MonoBehaviour
{
    [SerializeField]
    private float _forceValue;
    
    public Color CurrentColor;
    private Rigidbody _rigidBody;

    public void SetNewColor(Color newColor)
    {
        var renderer = GetComponent<Renderer>();
        
        renderer.materials[0].color = newColor;
        CurrentColor = newColor;
    }

    public void MoveSnowmanByForce(Vector3 direction)
    {
        _rigidBody = GetComponent<Rigidbody>();
        _rigidBody.velocity = Vector3.zero;
        
        _rigidBody.AddForce(new Vector3(direction.x, 0, direction.z) * _forceValue);

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Present"))
        {
            var present = collision.gameObject.GetComponent<Present>();
            if (CurrentColor.Equals(present.Color))
            {
                Destroy(collision.gameObject);
            }
        }
    }
    
}
