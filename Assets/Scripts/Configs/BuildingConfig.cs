using UnityEngine;
using UnityEngine.Serialization;

namespace Configs
{
    [CreateAssetMenu(menuName = nameof(BuildingConfig))]
    public class BuildingConfig : ScriptableObject
    {
        [FormerlySerializedAs("Name")] public string _name;
        [FormerlySerializedAs("Level")] public int _level;
        [FormerlySerializedAs("IncomeDelay")] public int _incomeDelay;
        [FormerlySerializedAs("BasicCost")] public int _basicCost;
        [FormerlySerializedAs("BasicIncome")] public int _basicIncome;
        [FormerlySerializedAs("Update1")] public UpgradeConfig _update1;
        [FormerlySerializedAs("Update2")] public UpgradeConfig _update2;
    }
}
