using UnityEngine;

[CreateAssetMenu(fileName = "UpdateItemConfig", menuName = "UpdateItemConfig")]
public class UpdateItemConfig : ScriptableObject
{
    [SerializeField] private ItemConfig _itemConfig;
    [SerializeField] private UpgradeType _upgradeType;
    [SerializeField] private float _valueUpdate;

    public int Id => _itemConfig.Id;
    public UpgradeType UpgradeType => _upgradeType;
    public float ValueUpdate => _valueUpdate;
}

public enum UpgradeType
{
    None,
    Speed,
    Control
}