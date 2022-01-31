using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightWindowController : BaseController
{
    private FightWindowView _fightWindowView;
    private ProfilePlayer _profilePlayer;


    private int _allCountMoneyPlayer;
    private int _allCountPowerPlayer;
    private int _allCountHealthPlayer;
    private int _allCountCrimePlayer;

    private Money _money;
    private Power _power;
    private Health _health;
    private Crime _crime;

    private Enemy _enemy;

    public FightWindowController(Transform placeForUi, ProfilePlayer profilePlayer, FightWindowView fightWindowView)
    {
        _profilePlayer = profilePlayer;

        _fightWindowView = Object.Instantiate(fightWindowView, placeForUi);
        AddGameObject(_fightWindowView.gameObject);
    }
    public void RefreshView()
    {
        _enemy = new Enemy("Enemy Car", 2);

        _money = new Money();
        _money.Attach(_enemy);

        _power = new Power();
        _power.Attach(_enemy);

        _health = new Health();
        _health.Attach(_enemy);

        _crime = new Crime();
        _crime.Attach(_enemy);

        _fightWindowView.PlusMoneyButton.onClick.AddListener(() => ChangeMoney(true));
        _fightWindowView.MinusMoneyButton.onClick.AddListener(() => ChangeMoney(false));

        _fightWindowView.PlusPowerButton.onClick.AddListener(() => ChangePower(true));
        _fightWindowView.MinusPowerButton.onClick.AddListener(() => ChangePower(false));

        _fightWindowView.PlusHealthButton.onClick.AddListener(() => ChangeHealth(true));
        _fightWindowView.MinusHealthButton.onClick.AddListener(() => ChangeHealth(false));

        _fightWindowView.PlusCrimeButton.onClick.AddListener(() => ChangeCrime(true));
        _fightWindowView.MinusCrimeButton.onClick.AddListener(() => ChangeCrime(false));

        _fightWindowView.LeaveButton.onClick.AddListener(LeaveFight);


        _fightWindowView.FightButton.onClick.AddListener(Fight);
    }

    protected override void OnDispose()
    {
        _fightWindowView.PlusMoneyButton.onClick.RemoveAllListeners();
        _fightWindowView.MinusMoneyButton.onClick.RemoveAllListeners();

        _fightWindowView.PlusPowerButton.onClick.RemoveAllListeners();
        _fightWindowView.MinusPowerButton.onClick.RemoveAllListeners();

        _fightWindowView.PlusHealthButton.onClick.RemoveAllListeners();
        _fightWindowView.MinusHealthButton.onClick.RemoveAllListeners();

        _fightWindowView.PlusCrimeButton.onClick.RemoveAllListeners();
        _fightWindowView.MinusCrimeButton.onClick.RemoveAllListeners();

        _fightWindowView.LeaveButton.onClick.RemoveAllListeners();

        _fightWindowView.FightButton.onClick.RemoveAllListeners();

        _money.Detach(_enemy);

        _power.Detach(_enemy);

        _health.Detach(_enemy);

        _crime.Detach(_enemy);

        base.OnDispose();
    }

    private void ChangeCrime(bool isAddCount)
    {
        if (isAddCount)
            _allCountCrimePlayer++;
        else
            _allCountCrimePlayer--;

        ChangeDataWindow(_allCountCrimePlayer, DataType.Crime);

    }

    private void ChangeMoney(bool isAddCount)
    {
        if (isAddCount)
            _allCountMoneyPlayer++;
        else
            _allCountMoneyPlayer--;

        ChangeDataWindow(_allCountMoneyPlayer, DataType.Money);

    }

    private void ChangePower(bool isAddCount)
    {
        if (isAddCount)
            _allCountPowerPlayer++;
        else
            _allCountPowerPlayer--;

        ChangeDataWindow(_allCountPowerPlayer, DataType.Power);
    }

    private void ChangeHealth(bool isAddCount)
    {
        if (isAddCount)
            _allCountHealthPlayer++;
        else
            _allCountHealthPlayer--;

        ChangeDataWindow(_allCountHealthPlayer, DataType.Health);
    }

    private void LeaveFight()
    {
        _profilePlayer.CurrentState.Value = GameState.Game;
    }

    private void Fight()
    {
        if (_allCountCrimePlayer >= _enemy.MaxCrimeLevel)
        {
            Debug.Log(_allCountPowerPlayer >= _enemy.Power ? "Win" : "Lose");
        }
        else
        {
            Debug.Log("you escaped");
        }
    }

    private void ChangeDataWindow(int countChangeData, DataType dataType)
    {
        switch (dataType)
        {
            case DataType.Money:
                _fightWindowView.CountMoneyText.text = $"Player Money: {countChangeData}";
                _money.CountMoney = countChangeData;
                break;

            case DataType.Power:
                _fightWindowView.CountPowerText.text = $"Player Power: {countChangeData}";
                _power.CountPower = countChangeData;
                break;

            case DataType.Health:
                _fightWindowView.CountHealthText.text = $"Player Health: {countChangeData}";
                _health.CountHealth = countChangeData;
                break;

            case DataType.Crime:
                _fightWindowView.CountCrimeText.text = $"Player Crime: {countChangeData}";
                _crime.CountCrime = countChangeData;
                break;
        }

        _fightWindowView.CountPowerEnemyText.text = $"Enemy Power: {_enemy.Power}";
    }
}
