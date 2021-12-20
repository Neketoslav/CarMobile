using JoostenProductions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class InputAcceleration : BaseInputView
{
    public override void Init(SubscribeProperty<float> leftMove, SubscribeProperty<float> rightMove, float speed)
    {
        base.Init(leftMove, rightMove, speed);
        UpdateManager.SubscribeToUpdate(Move);
    }

    private void OnDestroy()
    {
        UpdateManager.UnsubscribeFromUpdate(Move);
    }

    private void Move()
    {
        Vector3 direction = Vector3.zero;
        direction.x = -Input.acceleration.y;
        direction.z = Input.acceleration.x;

        if (direction.sqrMagnitude > 1)
            direction.Normalize();

        OnRightMove(direction.sqrMagnitude / 20 * _speed);
    }
}

