using System;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public event Action OnTouchWithPlayer;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        OnTouchWithPlayer += Open;
    }

    private void OnDestroy()
    {
        OnTouchWithPlayer -= Open;
    }

    public void Open()
    {
        _animator.SetTrigger("open");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnTouchWithPlayer?.Invoke();
        }
    }
}