using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class FightWindowView : MonoBehaviour
{
    [SerializeField] private TMP_Text _countMoneyText;
    [SerializeField] private TMP_Text _countPowerText;
    [SerializeField] private TMP_Text _countHealthText;
    [SerializeField] private TMP_Text _countCrimeText;
    [SerializeField] private TMP_Text _countPowerEnemyText;

    [SerializeField] private Button _plusMoneyButton;
    [SerializeField] private Button _minusMoneyButton;

    [SerializeField] private Button _plusPowerButton;
    [SerializeField] private Button _minusPowerButton;

    [SerializeField] private Button _plusHealthButton;
    [SerializeField] private Button _minusHealthButton;

    [SerializeField] private Button _plusCrimeButton;
    [SerializeField] private Button _minusCrimeButton;

    [SerializeField] private Button _leaveButton;
    [SerializeField] private Button _fightButton;


    public TMP_Text CountMoneyText => _countMoneyText; 
    public TMP_Text CountPowerText => _countPowerText;
    public TMP_Text CountHealthText => _countHealthText; 
    public TMP_Text CountCrimeText => _countCrimeText; 
    public TMP_Text CountPowerEnemyText  => _countPowerEnemyText;
    public Button PlusMoneyButton => _plusMoneyButton; 
    public Button MinusMoneyButton => _minusMoneyButton; 
    public Button PlusPowerButton => _plusPowerButton; 
    public Button MinusPowerButton  => _minusPowerButton;
    public Button PlusHealthButton => _plusHealthButton;
    public Button MinusHealthButton => _minusHealthButton; 
    public Button PlusCrimeButton => _plusCrimeButton; 
    public Button MinusCrimeButton => _minusCrimeButton;
    public Button LeaveButton => _leaveButton;
    public Button FightButton  => _fightButton;

}
