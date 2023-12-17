using UnityEngine;

public class LineDrawer : MonoBehaviour
{
    [SerializeField] private LineRenderer _lineRenderer;
    [SerializeField] private Camera _camera;
    [SerializeField] private MovementController _movementController;

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
            StartCoroutine(_movementController.MoveObjectOnLine(_lineRenderer));

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