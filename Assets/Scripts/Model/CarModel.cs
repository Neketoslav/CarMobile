using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarModel : IUpgradableCar
{
    public float defaultSpeed { get; }
    public float Speed { get; set ; }

    public CarModel(float speed)
    {
        defaultSpeed = speed;
        Restore();
    }

    public void Restore()
    {
        Speed = defaultSpeed;
    }
}
