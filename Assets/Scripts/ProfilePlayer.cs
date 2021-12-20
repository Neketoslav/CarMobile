using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilePlayer
{
    public ProfilePlayer(float speed)
    {
        CurrentState = new SubscribeProperty<GameState>();
        CurrentCar = new CarModel(speed);
    }

    public SubscribeProperty<GameState> CurrentState { get; }
    public CarModel CurrentCar { get; }
}
