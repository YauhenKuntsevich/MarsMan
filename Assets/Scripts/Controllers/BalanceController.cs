using System;
using Configs;
using Models;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public sealed class BalanceController : MonoBehaviour
    {
        private BalanceController() { }
        
        private static BalanceController _instance;

        public static BalanceController GetInstance()
        {
            if (_instance == null)
            {
                _instance = new BalanceController();
            }
            return _instance;
        }

        public void AddBalance(int income)
        {
            BalanceModel.Money += income;
        }

        public void WithdrawFromBalance(int amount)
        {
            if (BalanceCheck(amount))
            {
                BalanceModel.Money -= amount;
            }
        }
        
        public bool BalanceCheck(int amount)
        {
            return amount <= BalanceModel.Money;
        }
    }
}
