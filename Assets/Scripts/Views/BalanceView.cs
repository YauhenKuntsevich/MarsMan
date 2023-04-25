using Models;
using TMPro;
using UnityEngine;

namespace Views
{
    public sealed class BalanceView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _balanceText;

        private void Update()
        {
            _balanceText.text = BalanceModel.Money.ToString();
        }
    }
}