public class BuildingController
{
    private BuildingConfig _buildingConfig;
    public float IncomeCalculation()
    {
        return _buildingConfig.Level * _buildingConfig.BasicIncome * (1 + _buildingConfig.Update1.UpdateIncome + _buildingConfig.Update2.UpdateIncome);
    }

    public int LevelCost()
    {
        return (_buildingConfig.Level + 1) * _buildingConfig.BasicCost;
    }
}