using System.Collections.Generic;
using UnityEngine;

public class MainController : BaseController
{
    public MainController(Transform placeForUi, ProfilePlayer profilePlayer, List<ItemConfig> itemConfigs, List<AbilityItemConfig> abilityItemConfigs, DailyRewardView dailyRewardView, CurrencyView currencyView, FightWindowView fightWindowView, StartFightView startFightView)
    {
        _profilePlayer = profilePlayer;
        _placeForUi = placeForUi;
        _itemConfigs = itemConfigs;
        _abilityConfigs = abilityItemConfigs;
        _dailyRewardView = dailyRewardView;
        _currencyView = currencyView;
        _fightWindowView = fightWindowView;
        _startFightView = startFightView;
        OnChangeGameState(_profilePlayer.CurrentState.Value);
        profilePlayer.CurrentState.SubscribeOnChange(OnChangeGameState);
    }

    private MainMenuController _mainMenuController;
    private GameController _gameController;
    private DailyRewardController _dailyRewardController;
    private FightWindowController _fightWindowController;
    private StartFightController _startFightController;
    private InventoryController _inventoryController;
    private AbilityController _abilityController;

    private readonly DailyRewardView _dailyRewardView;
    private readonly CurrencyView _currencyView;
    private readonly FightWindowView _fightWindowView;
    private readonly StartFightView _startFightView;
    private readonly Transform _placeForUi;
    private readonly ProfilePlayer _profilePlayer;
    private readonly List<ItemConfig> _itemConfigs;
    private readonly List<AbilityItemConfig> _abilityConfigs;

    protected override void OnDispose()
    {
        DisposeAllControllers();
        _profilePlayer.CurrentState.UnSubscribeOnChange(OnChangeGameState);
        base.OnDispose();
    }

    private void OnChangeGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Start:
                _mainMenuController = new MainMenuController(_placeForUi, _profilePlayer);
                _gameController?.Dispose();
                _dailyRewardController?.Dispose();
                break;
            case GameState.Game:
                _inventoryController = new InventoryController(_placeForUi, _itemConfigs);
                _inventoryController.ShowInventory();

                _abilityController = new AbilityController(_placeForUi, _abilityConfigs);

                _gameController = new GameController(_profilePlayer);

                _startFightController = new StartFightController(_placeForUi, _profilePlayer, _startFightView);

                _mainMenuController?.Dispose();
                _fightWindowController?.Dispose();
                break;

            case GameState.DailyReward:
                _dailyRewardController = new DailyRewardController(_placeForUi, _profilePlayer, _dailyRewardView, _currencyView);
                _dailyRewardController.RefreshView();
                _mainMenuController?.Dispose();
                break;

            case GameState.Fight:
                _fightWindowController = new FightWindowController(_placeForUi, _profilePlayer, _fightWindowView);
                _fightWindowController.RefreshView();
                _startFightController?.Dispose();
                _gameController?.Dispose();
                _inventoryController?.Dispose();
                _abilityController?.Dispose();
                break;

            default:
                DisposeAllControllers();
                break;
        }
    }
    private void DisposeAllControllers()
    {
        _inventoryController?.Dispose();
        _abilityController?.Dispose();
        _mainMenuController?.Dispose();
        _gameController?.Dispose();
        _fightWindowController?.Dispose();
        _dailyRewardController?.Dispose();
        _startFightController?.Dispose();
    }
}