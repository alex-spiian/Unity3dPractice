using System;
using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    public event Action<Vector3[]> OnMovingBox;
    
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Camera _camera;
    
    private int _currentIndex = 1;
    private bool _isLineDrawn;
    private bool _isDrawing;

    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0) && !_isLineDrawn)
        {
            _isDrawing = true;
        }

        if (Input.GetMouseButtonUp(0) && !_isLineDrawn)
        {
            _isDrawing = false;
            _isLineDrawn = true;

            Vector3[] positions = new Vector3[_lineRenderer.positionCount];
            _lineRenderer.GetPositions(positions);
            
            OnMovingBox?.Invoke(positions);
            
        }

        if (_isDrawing && !_isLineDrawn)
        {
            ContinueDrawing();
        }
        
        
    }
    

    private void ContinueDrawing()
    {
        var mousePosition = Input.mousePosition;
        mousePosition.z = Mathf.Abs(_camera.transform.position.z - transform.position.z);

        var worldPosition = _camera.ScreenToWorldPoint(mousePosition);

        _lineRenderer.positionCount = _currentIndex + 1;
        _lineRenderer.SetPosition(_currentIndex, worldPosition);
        _currentIndex++;
        
    }
    
    
}