using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UpgradeItemConfigDataSource", menuName = "UpgradeItemConfigDataSource")]
public class UpgradeItemConfigDataSource : ScriptableObject
{
    [SerializeField] private UpdateItemConfig[] _itemConfigs;

    public UpdateItemConfig[] ItemConfigs => _itemConfigs;
}
