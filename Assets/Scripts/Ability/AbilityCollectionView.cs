using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
{
    public event Action<IItem> UseRequesed;

    private IReadOnlyList<IItem> _abilityItems;

    private void OnUseRequesed(IItem item)
    {
        UseRequesed.Invoke(item);
    }
    public void Show()
    {

    }
    public void Display(IReadOnlyList<IItem> abilityItems)
    {
        _abilityItems = abilityItems;
        foreach (var item in abilityItems)
        {
            Debug.Log(item.Info.Title);
        }
    }
}
