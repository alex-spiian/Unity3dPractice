using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DrumController : MonoBehaviour
{

    [SerializeField] private HingeJoint _hingeJoint;

    private const float START_SPEED = 50;
    private const float STOP_SPEED = 0;
    private const float SPEED_STEP = 10;
    
    public void StartRotation()
    {
        var hingeJointMotor = _hingeJoint.motor;
        hingeJointMotor.targetVelocity = START_SPEED;
        _hingeJoint.motor = hingeJointMotor;
    }

    public void StopRotation()
    {
        var hingeJointMotor = _hingeJoint.motor;
        hingeJointMotor.targetVelocity = STOP_SPEED;
        _hingeJoint.motor = hingeJointMotor;
    }

    public void SpeedUp()
    {
        var hingeJointMotor = _hingeJoint.motor;
        hingeJointMotor.targetVelocity += SPEED_STEP;
        _hingeJoint.motor = hingeJointMotor;
    }

    public void SpeedDown()
    {
        var hingeJointMotor = _hingeJoint.motor;
        hingeJointMotor.targetVelocity -= SPEED_STEP;
        _hingeJoint.motor = hingeJointMotor;
    }
}
