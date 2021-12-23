using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class CarController : BaseController
{
    private readonly ResourcesPath _viewPath = new ResourcesPath { PathResources = "Prefabs/Car" };
    private readonly CarView _carView;

    public CarController()
    {
        _carView = LoadView();
    }

    private CarView LoadView()
    {
        var objectView = Object.Instantiate(ResourcesLoader.LoadPrefab(_viewPath));
        AddGameObject(objectView);

        return objectView.GetComponent<CarView>();
    }
    public GameObject GetViewObject()
    {
        return _carView.gameObject;
    }

}
