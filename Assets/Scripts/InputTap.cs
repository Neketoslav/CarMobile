using JoostenProductions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class InputTap : BaseInputView
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
        float moveStep = 10 * Time.deltaTime * Input.GetAxis("Horizontal");
        OnRightMove(moveStep);
    }
}
