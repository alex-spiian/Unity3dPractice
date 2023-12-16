using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private Material _cursorMaterial;
        
        public void InstantiateCursor()
        {
            Instantiate(gameObject);
        }

        public void ChangeColor(Color newColor)
        {
            _cursorMaterial.color = newColor;
        }

        private void Update()
        {
            transform.position = MousePositionController.GetMousePositionInWorld();
        }
    }
}