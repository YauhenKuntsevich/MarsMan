using TMPro;
using UnityEngine;

namespace Controllers
{
    public sealed class BalanceModel : MonoBehaviour
    {
        public static long Money { get; set; }

        public static bool BalanceCheck(int amount)
        {
            return amount <= Money;
        }
    }
}