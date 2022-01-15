using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombAbility : IAbility
{
    private readonly AbilityItemConfig _config;

    public BombAbility(AbilityItemConfig config)
    {
        _config = config;
    }


    public void Apply()
    {
        var bomb = Object.Instantiate(_config.View);
        var rb2D = bomb.GetComponent<Rigidbody2D>();
        rb2D.AddForce(Vector2.right * _config.Value, ForceMode2D.Impulse);
    }
}
