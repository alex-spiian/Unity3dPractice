using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chalk : MonoBehaviour
{
    
    [SerializeField]
    private LineRenderer _lineRenderer;
    
    private int _currentIndex;
    
    public void DrawLine(Vector3 mousePositionInWorld)
    {
        _lineRenderer.positionCount = _currentIndex + 1;

        _lineRenderer.SetPosition(_currentIndex, mousePositionInWorld);
        
        _currentIndex++;
    }

    public void ChangeColor(Color color)
    {
        _lineRenderer.material.color = color;
    }
    
}
