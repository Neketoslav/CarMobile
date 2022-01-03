using System;
using System.Collections.Generic;
using UnityEngine;

public interface IInventoryView 
{
    void OnEquipped();
    void Display(IReadOnlyList<IItem> items);
}
