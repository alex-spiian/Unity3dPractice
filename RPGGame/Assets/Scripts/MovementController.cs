using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    private NavMeshAgent _navMeshAgent;
    private Vector3 _destination;

    private void Awake()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Physics.Raycast(ray, out var hitInfo, 50f);

        if (Input.GetMouseButton(0))
        {
            _destination = hitInfo.point;
        }
        
        // Перемещаем персонажа в направлении _destination.
        _navMeshAgent.SetDestination(_destination);
        
    }
}