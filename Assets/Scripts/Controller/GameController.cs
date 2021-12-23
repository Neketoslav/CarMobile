using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseController
{
    public GameController(ProfilePlayer profilePlayer)
    {
        var leftMoveDiff = new SubscribeProperty<float>();
        var rightMoveDiff = new SubscribeProperty<float>();

        var carController = new CarController();
        AddController(carController);

        var backGround = new TapeBackgroundController(leftMoveDiff, rightMoveDiff);
        AddController(backGround);

        var inputGameController = new InputGameController(leftMoveDiff, rightMoveDiff, profilePlayer.CurrentCar);
        AddController(inputGameController);
    }
}
