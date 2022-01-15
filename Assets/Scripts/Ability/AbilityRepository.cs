using System.Collections.Generic;
using UnityEngine;

public class AbilityRepository : BaseController, IRepository<int, IAbility>
{
    public IReadOnlyDictionary<int, IAbility> Collection => _abilityMapById;

    private Dictionary<int, IAbility> _abilityMapById = new Dictionary<int, IAbility>();

    public AbilityRepository(List<AbilityItemConfig> configs)
    {
        PopulateItems(configs);
    }

    private void PopulateItems(List<AbilityItemConfig> configs)
    {
        foreach(var config in configs)
        {
            if (_abilityMapById.ContainsKey(config.Id))
                continue;

            _abilityMapById.Add(config.Id, CreateAbility(config));
        }
    }

    private IAbility CreateAbility(AbilityItemConfig config)
    {
        switch (config.AbilityType)
        {
            case AbilityType.Gun:
                return new BombAbility(config);
            default:
                Debug.LogError("Not type ability");
                return null;
        }
    }

    protected override void OnDispose()
    {
        _abilityMapById.Clear();
    }
}
