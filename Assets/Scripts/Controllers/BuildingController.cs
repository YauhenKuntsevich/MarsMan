using System;
using Configs;
using TMPro;
using UnityEngine;

public sealed class BuildingController : MonoBehaviour
{
    [SerializeField] private BuildingsConfigs _buildingsConfigs;
    
    private BuildingController() { }
        
    private static BuildingController _instance;
    public static BuildingController GetInstance()
    {
        if (_instance == null)
        {
            _instance = new BuildingController();
        }
        return _instance;
    }
    
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