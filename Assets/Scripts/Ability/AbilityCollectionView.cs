using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityCollectionView : MonoBehaviour, IAbilityCollectionView
{
    [SerializeField] private GameObject _abilityScreen;

    public event Action<IItem> UseRequesed;

    private IReadOnlyList<IItem> _abilityItems;

    private void OnUseRequesed(IItem item)
    {
        UseRequesed.Invoke(item);
    }
    public void Show( )
    {
        Debug.Log("show");
        Debug.Log(_abilityScreen);
        _abilityScreen.gameObject.SetActive(true);
    }
    public void Hide()
    {
        Debug.Log("hide");
        _abilityScreen.SetActive(false);
    }
}
