using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeBackgroundView : MonoBehaviour
{
    [SerializeField]
    private Background[] _backgrounds;

    private IReadOnlySubscribeProperty<float> _diff;

    public void Init(IReadOnlySubscribeProperty<float> diff)
    {
        _diff = diff;
        _diff.SubscribeOnChange(Move);
    }

    protected void OnDestroy()
    {
        _diff?.SubscribeOnChange(Move);
    }

    private void Move(float value)
    {
        foreach (var background in _backgrounds)
            background.Move(-value);
    }
}
