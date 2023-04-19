using System;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public sealed class BalanceController : MonoBehaviour
    {
        private BalanceController() { }
        
        private static BalanceController _instance;
        private readonly BalanceModel _balanceModel;

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
            if (BalanceModel.BalanceCheck(amount))
            {
                BalanceModel.Money -= amount;
            }
        }
    }
}
