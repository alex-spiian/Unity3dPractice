using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField] private Transform _itemSlotTransform;
    [SerializeField] private float _throwForce;
    [SerializeField] private float _lenghtOfRay;
    
    private InteractableItem _itemPlayerIsLookingAt;
    private Transform _selectedItemTransform;
    private int _countItemsInHolder;
    private Door _door;
    
    private const int MAX_COUNT_ITEMS_IN_HOLDER = 1;
    private const string DOOR_TAG = "Door";
    private const string INTERACTABLE_ITEM_TAG = "Interactable";
    private void Update()
    {
        var ray = RayFromCamera.Ray(_lenghtOfRay);

        if (ray.HasValue)
        {
            ActionsWithInteractableObjects(ray);
            ActionsWithDoors(ray);
        }
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowItemForward();
        }
    }
    private void ActionsWithInteractableObjects(RaycastHit? ray)
    {
        if (ray.Value.transform.CompareTag(INTERACTABLE_ITEM_TAG))
        {
            _itemPlayerIsLookingAt = ray.Value.transform.GetComponent<InteractableItem>();
            _itemPlayerIsLookingAt.SetFocus();
            TryToPickUpItem(ray.Value.transform);
        }

        else
        {
            if (_itemPlayerIsLookingAt != null)
            {
                _itemPlayerIsLookingAt.RemoveFocus();
            }
        }
        
    }
    private void TryToPickUpItem(Transform itemTransform)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (_countItemsInHolder < MAX_COUNT_ITEMS_IN_HOLDER)
            {
                
                SetItemInHolder(itemTransform);
            }
            else
            {
                ThrowItemOnGround();
                SetItemInHolder(itemTransform);
            }
        }
    }
    private void SetItemInHolder(Transform itemTransform)
    {
        _itemPlayerIsLookingAt.RemoveFocus();

        Rigidbody itemRigidbody = itemTransform.GetComponent<Rigidbody>();
        if (itemRigidbody != null)
        {
            itemRigidbody.isKinematic = true;
            _countItemsInHolder++;
            _selectedItemTransform = itemTransform;
        }
       
        _selectedItemTransform.SetParent(_itemSlotTransform);
        _selectedItemTransform.position = _itemSlotTransform.position;
        _selectedItemTransform.rotation = new Quaternion(0, 0, 0, 0);

    }
    private void ThrowItemForward()
    {

        if (_selectedItemTransform != null)
        {
            _itemSlotTransform.DetachChildren();
            Rigidbody itemRigidbody = _selectedItemTransform.GetComponent<Rigidbody>();
            itemRigidbody.isKinematic = false;
            itemRigidbody.AddForce(_itemSlotTransform.forward * _throwForce, ForceMode.Impulse);
            _countItemsInHolder--;
            
        }
    }
    private void ThrowItemOnGround()
    {
        Rigidbody itemRigidbody = _selectedItemTransform.GetComponent<Rigidbody>();
        itemRigidbody.isKinematic = false;
        _itemSlotTransform.DetachChildren();
        _countItemsInHolder--;
    }
    private void ActionsWithDoors(RaycastHit? ray)
    {
        if (ray.Value.transform.CompareTag(DOOR_TAG))
        {
            _door = ray.Value.transform.GetComponent<Door>();

            if (Input.GetKeyDown(KeyCode.E))
            {
                _door.SwitchDoorState();
            }
        }
    }
    
}
