using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(menuName = nameof(BuildingConfig))]
    public class BuildingConfig : ScriptableObject
    {
        public string Name;
        public int Level;
        public int IncomeDelay;
        public int BasicCost;
        public int BasicIncome;
        public UpgradeConfig Update1;
        public UpgradeConfig Update2;
    }
}
