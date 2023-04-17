using UnityEngine;

public class BuildingController : MonoBehaviour
{
    [SerializeField] private BuildingsConfigs _buildingsConfigs;
    
    public int IncomeCalculation(BuildingConfig buildingConfig)
    {
        return (int)(buildingConfig.Level * buildingConfig.BasicIncome * (1 + buildingConfig.Update1.UpdateIncome + buildingConfig.Update2.UpdateIncome));
    }

    public int LevelCost(int level, int basicCost)
    {
        return (level + 1) * basicCost;
    }

    public void ChangeLevel(string buildingName)
    {
        foreach (var building in _buildingsConfigs.Buildings)
        {
            if (building.Name == buildingName)
            {
                building.Level++;
                return;
            }
        }
    }
}