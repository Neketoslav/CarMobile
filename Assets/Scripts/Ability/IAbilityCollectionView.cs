using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAbilityCollectionView
{
    event Action<IItem> UseRequesed;
    void Show();
    void Hide();
}
