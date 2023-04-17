using System;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class BalanceController : MonoBehaviour
    {
        [SerializeField] private TMP_Text _balanceText;

        private long Money { get; set; }

        private void Start()
        {
            Money = 4;
            Console.WriteLine(Money);
        }
        private void Update()
        {
            _balanceText.text = "Balance: " + Money;
        }

        public bool BalanceCheck(int amount)
        {
            return amount <= Money;
        }
    
        public void AddBalance(int income)
        {
            Money += income;
        }

        public void WithdrawFromBalance(int amount)
        {
            if (BalanceCheck(amount))
            {
                Money -= amount;
            }
        }
    }
}
