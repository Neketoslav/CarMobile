using JoostenProductions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

internal class InputSwipe : BaseInputView, IBeginDragHandler, IDragHandler
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
        OnRightMove(Time.deltaTime * _speed);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(Mathf.Abs(eventData.delta.x) > Mathf.Abs(eventData.delta.y))
        {
            if (eventData.delta.x > 0)
                Move();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
       
    }
}
