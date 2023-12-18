using System;
using System.Collections;
using DefaultNamespace;
using Obi;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    public event Action OnPlayerLost;
    public event Action OnPlayerWon;

    [SerializeField]
    private MovementController _movementController;
    [SerializeField]
    private GameObject _rope;
    [SerializeField] 
    private float _speed;
    [SerializeField]
    private Transform _landingPointTransform;
    
    private ObiParticleAttachment _ropeAttachment;
    private bool _wasCargoDelivered;

    private void Awake()
    {
        
        // Получаем ссылку на крепление ящика к веревке:
        var ropeAttachments = _rope.GetComponents<ObiParticleAttachment>();
        foreach (var ropeAttachment in ropeAttachments)
        {
            if (ropeAttachment.target.gameObject == gameObject)
            {
                _ropeAttachment = ropeAttachment;
                break;
            }
        }
    }

    private void Update()
    {
        if (_movementController.IsRopeAtFinish && !_wasCargoDelivered)
        {
            OnPlayerLost?.Invoke();
        }
    }

    private void OnCollisionEnter()
    {
        // Отцепляем ящик от веревки
        _ropeAttachment.enabled = false;
        OnPlayerLost?.Invoke();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(GlobalConstants.FINISH_POINT_TAG))
        {
            _wasCargoDelivered = true;
            DropDown(_landingPointTransform.position);

        }
    }

    public void MoveBox(Vector3[] positions)
    {
        StartCoroutine(_movementController.MoveObjectOnLine(positions));
    }

    private void DropDown(Vector3 position)
    {
        // Делаем соединение с веревкой статичным (чтоб она растягивалась при движении ящика)
        _ropeAttachment.attachmentType = ObiParticleAttachment.AttachmentType.Static;
        
        // Выключаем Rigidbodies ящика
        GetComponent<ObiRigidbody>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true; 
        
        // Перемещаем ящик в точку ровно над финишем
        transform.rotation = Quaternion.identity;
        transform.position = new Vector3(position.x, transform.position.y, transform.position.z);

        // Медленно двигаем ящик вниз
        StartCoroutine(DeliverToTarget(position));
    }
    
    private IEnumerator DeliverToTarget(Vector3 targetPosition)
    {
        // Пока позиция ящика не совпадет с позицией финишной точки
        while(transform.position != targetPosition)
        {
            // Меняем позицию ящика в соответствии со скоростью
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, 
                _speed * Time.deltaTime);
            
            // Пропускаем кадр
            yield return null;
        }
        
        // Когда ящик занял нужную позицию - отцепляем ящик от веревки
        OnPlayerWon?.Invoke();
        _ropeAttachment.enabled = false;
    }

}