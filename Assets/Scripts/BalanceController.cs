using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Debug = System.Diagnostics.Debug;

public class BalanceController : MonoBehaviour
{
    [SerializeField] private TMP_Text _balanceText;
    private void Start()
    {
        //InvokeRepeating($"AddBalance", 3, 3); //Увеличивает баланс каждые три секунды
    }

    private void Update()
    {
        _balanceText.text = "Баланс: " + Balance.Money;
    }

    private void AddBalance(int income)
    {
        Balance.Money += income;
        print(Balance.Money);
    }
}
