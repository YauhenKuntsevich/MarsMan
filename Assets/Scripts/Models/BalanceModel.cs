using System;
using Configs;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

namespace Models
{
    public class BalanceModel : MonoBehaviour
    {
        [SerializeField] private BalanceConfig _balanceConfig;
        public static long Money { get; set; } = 0;

        private void Start()
        {
            Money = _balanceConfig.Money;
        }

        private void Update()
        {
            _balanceConfig.Money = Money;
        }
    }
}