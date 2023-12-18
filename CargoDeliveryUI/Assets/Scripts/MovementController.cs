using System;
using System.Collections;
using UnityEngine;

[Serializable]
public class MovementController
{
    
    public bool IsRopeAtFinish;
    
    [SerializeField]
    private Transform _ropeTransform;
    [SerializeField]
    private Transform _finishPositionTransform;
    [SerializeField]
    private float _speed;

    
    public IEnumerator MoveObjectOnLine(Vector3[] positions)
    {

        foreach (var targetPosition in positions)
        {
            while (_ropeTransform.position != targetPosition)
            {
                _ropeTransform.position = Vector3.MoveTowards(_ropeTransform.position, targetPosition, _speed * Time.deltaTime);

                if (_ropeTransform.position.x <= _finishPositionTransform.position.x)
                {
                    
                    yield break;
                }

                if (_ropeTransform.position.x == positions[^1].x)
                {
                    IsRopeAtFinish = true;
                }
                
                yield return null;
            }
        }
    }
    
}