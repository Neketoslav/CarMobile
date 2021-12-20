using System.Collections;
using System.Collections.Generic;
using UnityEngine;

internal class InputGameController : BaseController
{
    public InputGameController(SubscribeProperty<float> leftMove, SubscribeProperty<float> rightMove, CarModel car)
    {
        _view = LoadView();
        _view.Init(leftMove, rightMove, car.Speed);
    }

    private readonly ResourcesPath _viewPath = new ResourcesPath { PathResources = "Prefabs/gyroscopeMove" };
    private BaseInputView _view;

    private BaseInputView LoadView()
    {
        GameObject objView = Object.Instantiate(ResourcesLoader.LoadPrefab(_viewPath));
        AddGameObject(objView);
        return objView.GetComponent<BaseInputView>();
    }
}

