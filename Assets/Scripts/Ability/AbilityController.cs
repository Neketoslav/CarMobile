using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityController : BaseController
{
    private readonly ResourcesPath _buttonViewPath = new ResourcesPath() { PathResources = "Prefabs/ShowAbilityButton" };
    private readonly ResourcesPath _abilityScreen = new ResourcesPath() { PathResources = "Prefabs/AbilityScreen" };


    private readonly IInventoryModel _inventoryModel;
    private readonly IAbilityCollectionView _abilityView;
    private readonly AbilityRepository _abilityRepository;
    private Transform _placeForUi;
    private bool _AbilityScreenIsActive;

    private readonly Dictionary<int, IAbility> _ability;

    public AbilityController(Transform placeForUi, List<AbilityItemConfig> abilityConfigs)
    {
        _inventoryModel = new InventoryModel();
        _abilityView = new AbilityCollectionView();
        _abilityRepository = new AbilityRepository(abilityConfigs);
        _placeForUi = placeForUi;

        var AbilitiesButton = Object.Instantiate(ResourcesLoader.LoadPrefab(_buttonViewPath), placeForUi, false);
        var _buttonShowAbilities = AbilitiesButton.GetComponent<Button>();
        _buttonShowAbilities.onClick.AddListener(ButtonClick);

        var ShowAbilitiesScreen = Object.Instantiate(ResourcesLoader.LoadPrefab(_abilityScreen), placeForUi, false);
    }
    private void ButtonClick()
    {
        ShowAbilities();
    }
    public void ShowAbilities()
    {
        if (!_AbilityScreenIsActive)
        {
            _abilityView.Show();
            _AbilityScreenIsActive = true;
        }
        else
        {
            _abilityView.Hide();
            _AbilityScreenIsActive = false;
        }
    }

    protected override void OnDispose()
    {
        _ability.Clear();
    }
}

