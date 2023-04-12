public class BuildingController
{
    internal static int IncomeCalculation()
    {
        return Building.Level * Building.BasicIncome * (1 + Building._upgrades[0].UpgradeIncome + Building._upgrades[1].UpgradeIncome);
    }

    internal static int LevelCost()
    {
        return (Building.Level + 1) * Building.BasicCost;
    }
}