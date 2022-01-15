using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour, IInventoryView
{
    [SerializeField] public Transform _itemsSlot;

    public void OnEquipped()
    {

    }
    public void Display(IReadOnlyList<IItem> items)
    {
        foreach (var item in items)
        {
            Debug.Log(item.Info.Title);
        }

    }
}
