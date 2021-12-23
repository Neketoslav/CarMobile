using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProfilePlayer
{
    public ProfilePlayer(float speed, UnityAdsTools unityAdsTools)
    {
        CurrentState = new SubscribeProperty<GameState>();
        CurrentCar = new CarModel(speed);
        AnalyticTools = new UnityAnalyticTools();
        AdsShower = unityAdsTools;
    }

    public SubscribeProperty<GameState> CurrentState { get; }
    public CarModel CurrentCar { get; }

    public IAnalyticTools AnalyticTools { get; }
    public IAdsShower AdsShower { get; }

}
