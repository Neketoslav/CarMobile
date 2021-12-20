using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : BaseController
{
    public GameController(ProfilePlayer profilePlayer)
    {
        var carController = new CarController();
        AddController(carController);
    }
}
