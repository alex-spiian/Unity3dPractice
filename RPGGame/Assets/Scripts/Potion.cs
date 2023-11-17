using UnityEngine;

public class Potion : MonoBehaviour
{
    public bool HasPlayerPickedUpPotion;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            HasPlayerPickedUpPotion = true;
            Destroy(gameObject);
        }
    }
    
}
