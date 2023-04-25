using Configs;
using UnityEngine;

namespace Models
{
    public class BalanceModel : MonoBehaviour
    {
        [SerializeField] private BalanceConfig _balanceConfig;
        public static long Money { get; set; }

        private void Start()
        {
            Money = _balanceConfig._money;
        }

        private void Update()
        {
            _balanceConfig._money = Money;
        }
    }
}