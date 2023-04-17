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

    private Balance _balance;

    private void Update()
    {
        _balanceText.text = "Баланс: " + _balance.Money;
    }

    public bool BalanceCheck(int amount)
    {
        return amount <= _balance.Money;
    }
    
    public void AddBalance(int income)
    {
        _balance.Money += income;
    }

    public void WithdrawFromBalance(int amount)
    {
        if (BalanceCheck(amount))
        {
            _balance.Money -= amount;
        }
    }
}
