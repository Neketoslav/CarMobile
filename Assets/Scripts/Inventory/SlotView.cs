using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SlotView : MonoBehaviour
{
    [SerializeField] private Text _titleText;
    public void Init(IItem item)
    {
    _titleText.text = item.Info.Title;
    }
}
