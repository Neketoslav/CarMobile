using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal abstract class BaseInputView : MonoBehaviour
{
    public virtual void Init(SubscribeProperty<float> leftMove, SubscribeProperty<float> rightMove, float speed)
    {
        _leftMove = leftMove;
        _rightMove = rightMove;
        _speed = speed;
    }


    protected float _speed;
    private SubscribeProperty<float> _leftMove;
    private SubscribeProperty<float> _rightMove;

    protected virtual void OnLeftMove(float value)
    {
        _leftMove.Value = value;
    }

    protected virtual void OnRightMove(float value)
    {
        _rightMove.Value = value;
    }
}

