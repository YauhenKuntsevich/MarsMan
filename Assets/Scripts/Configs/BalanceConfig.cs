using UnityEngine;
using UnityEngine.Serialization;

namespace Configs
{
    [CreateAssetMenu(menuName = nameof(BalanceConfig))]
    public class BalanceConfig : ScriptableObject
    {
        [FormerlySerializedAs("Money")] public long _money;
    }
}