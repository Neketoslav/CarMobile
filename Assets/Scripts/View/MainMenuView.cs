using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] 
    private Button _buttonStart;
    [SerializeField] 
    private Button _buttonDailyReward;
    [SerializeField] 
    private Button _buttonExit;

    public void Init(UnityAction startGame, UnityAction dailyReward)
    {
        _buttonStart.onClick.AddListener(startGame);
        _buttonDailyReward.onClick.AddListener(dailyReward);
        _buttonExit.onClick.AddListener(ExitGame);
    }

    private void ExitGame()
    {
        Application.Quit();
    }

    private void OnDestroy()
    {
        _buttonStart.onClick.RemoveAllListeners();
        _buttonDailyReward.onClick.RemoveAllListeners();
        _buttonExit.onClick.RemoveAllListeners();
    }
}
