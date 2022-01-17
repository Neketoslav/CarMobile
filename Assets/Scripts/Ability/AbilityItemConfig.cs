using UnityEngine;

[CreateAssetMenu(fileName = "AbilityItemConfig", menuName = "AbilityItemConfig")]
public class AbilityItemConfig : ScriptableObject
{
    [SerializeField] public ItemConfig ItemConfig;
    [SerializeField] public GameObject View;

    public AbilityType AbilityType;
    public float Value;

    public int Id => ItemConfig.Id;
}
public enum AbilityType
{
    None,
    Gun
}
