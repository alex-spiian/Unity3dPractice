using UnityEngine;

namespace DefaultNamespace.RotationBehaviour
{
    public class RotationBehaviour : MonoBehaviour
    {
        [SerializeField]
        private float _rotationSpeed;

        private void Update()
        {
            transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
        }
    }
}