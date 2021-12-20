using UnityEngine;

public class MainMenuController : BaseController
{
    private readonly ResourcesPath _viewPath = new ResourcesPath { PathResources = "Prefabs / MainMenu" };
    private readonly ProfilePlayer _profilePlayer;
    private readonly MainMenuView _mainMenuView;

    public MainMenuController(Transform placeForUi, ProfilePlayer profilePlayer)
    {
        _profilePlayer = profilePlayer;
        _mainMenuView = LoadView(placeForUi);
        _mainMenuView.Init(StartGame);
    }

    private MainMenuView LoadView(Transform placeForUi)
    {
        var objectView = Object.Instantiate(ResourcesLoader.LoadPrefab(_viewPath), placeForUi, false);
        AddGameObject(objectView);

        return objectView.GetComponent<MainMenuView>();
    }
    
    private void StartGame()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
    }
}
