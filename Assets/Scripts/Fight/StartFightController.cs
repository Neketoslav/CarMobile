using UnityEngine;

public class StartFightController : BaseController
{
    private StartFightView _startFightView;
    private ProfilePlayer _profilePlayer;
    public StartFightController(Transform placeForUi, ProfilePlayer profilePlayer, StartFightView startFightView)
    {
        _profilePlayer = profilePlayer;

        _startFightView = Object.Instantiate(startFightView, placeForUi);
        AddGameObject(_startFightView.gameObject);

        SubscribeButtons();
    }

    private void SubscribeButtons()
    {
        _startFightView.StartFightButton.onClick.AddListener(StartFight);
    }

    private void StartFight()
    {
        _profilePlayer.CurrentState.Value = GameState.Fight;
    }

    protected override void OnDispose()
    {
        _startFightView.StartFightButton.onClick.RemoveAllListeners();

        base.OnDispose();
    }
}
