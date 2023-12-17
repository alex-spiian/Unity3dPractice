using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class MovementController
{

    [SerializeField]
    private Transform _ropeTransform;
    [SerializeField]
    private Transform _finishPositionTransform;
    [SerializeField]
    private float _speed;

    
    public IEnumerator MoveObjectOnLine(LineRenderer lineRenderer)
    {
        var positions = new Vector3[lineRenderer.positionCount];
        
        lineRenderer.GetPositions(positions);
    
        foreach (var targetPosition in positions)
        {
            while (_ropeTransform.position != targetPosition)
            {
                _ropeTransform.position = Vector3.MoveTowards(_ropeTransform.position, targetPosition, _speed * Time.deltaTime);

                if (_ropeTransform.position.x <= _finishPositionTransform.position.x)
                {
                    yield break;
                }
                
                yield return null;
            }
        }
    }
}
