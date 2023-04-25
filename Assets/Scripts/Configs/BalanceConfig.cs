using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = nameof(BalanceConfig))]
    public class BalanceConfig : ScriptableObject
    {
        public long Money;
    }
}