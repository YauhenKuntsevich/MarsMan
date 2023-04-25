using Models;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public sealed class BalanceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _balanceText;
        
        private void Start()
        {
            BalanceModel.Money = 8;
        }

        private void Update()
        {
            _balanceText.text = "Balance: " + BalanceModel.Money;
        }
    }
}