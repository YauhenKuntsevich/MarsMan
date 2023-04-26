using Configs;
using Views;

namespace Controllers
{
    public sealed class BuildingController 
    {
        private BuildingView _buildingPrefab;
    
        private BuildingController() { }
        
        private static BuildingController _instance;
        private BalanceController _balanceController = BalanceController.GetInstance();

        public static BuildingController GetInstance()
        {
            if (_instance != null) return _instance;
            _instance = new BuildingController();
            return _instance;
        }

        public int LevelCost(int level, int basicCost)
        {
            return (level + 1) * basicCost;
        }

        public void ChangeLevel(BuildingConfig buildingConfig)
        {
            _balanceController.WithdrawFromBalance(LevelCost(buildingConfig._level, buildingConfig._basicCost));
            buildingConfig._level++;
        }

        public int IncomeCalculation(BuildingConfig buildingConfig)
        {
            return (int)(buildingConfig._level * buildingConfig._basicIncome * (1 + (buildingConfig._update1._updateIs ? buildingConfig._update1._updateIncome : 0) + (buildingConfig._update2._updateIs ? buildingConfig._update2._updateIncome : 0)));
        }

        // public void AccrueIncome(BuildingConfig building)
        // {
        //     BalanceController.AddBalance(IncomeCalculation(building));
        // }
    }
}