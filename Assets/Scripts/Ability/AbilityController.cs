using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityController : BaseController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IAbilityCollectionView _abilityView;
    private readonly AbilityRepository _abilityRepository;
    private Transform _placeForUi;

    private readonly Dictionary<int, IAbility> _ability;

    public AbilityController(Transform placeForUi, List<AbilityItemConfig> abilityConfigs)
    {
        _inventoryModel = new InventoryModel();
        _abilityView = new AbilityCollectionView();
        _abilityRepository = new AbilityRepository(abilityConfigs);
        _placeForUi = placeForUi;
    }

    public void ShowAbilities()
    {
        foreach (var ability in _abilityRepository.Collection.Values)

        _abilityView.Show();
        _abilityView.Display(_inventoryModel.GetEquippedItems());
    }

    protected override void OnDispose()
    {
        _ability.Clear();
    }
}

