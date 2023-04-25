using System;
using Configs;
using Controllers;
using TMPro;
using UnityEngine;
using Views;

public sealed class BuildingController : MonoBehaviour
{
    [SerializeField] private BuildingsConfigs _buildingsConfigs;
    [SerializeField] private BuildingView _buildingPrefab;
    
    private readonly BalanceController _balanceController = BalanceController.GetInstance();
    
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

    public int LevelCost(int level, int basicCost)
    {
        return (level + 1) * basicCost;
    }

    public void ChangeLevel(string buildingName)
    {
        Debug.Log("Дошли сюда");
        foreach (var building in _buildingsConfigs.Buildings)
        {
            Debug.Log("Конфиг есть");
            if (building.Name == buildingName)
            {
                _balanceController.WithdrawFromBalance(LevelCost(building.Level, building.BasicCost));
                building.Level++;
                _buildingPrefab.BuildingLevelUp(building.Level);
                return;
            }
        }
    }

    public int IncomeCalculation(BuildingConfig buildingConfig)
    {
        return (int)(buildingConfig.Level * buildingConfig.BasicIncome * (1 + (buildingConfig.Update1.UpdateIs ? buildingConfig.Update1.UpdateIncome : 0) + (buildingConfig.Update2.UpdateIs ? buildingConfig.Update2.UpdateIncome : 0)));
    }

    public void AccrueIncome(string buildingName)
    {
        foreach (var building in _buildingsConfigs.Buildings)
        {
            if (building.Name == buildingName)
            {
                _balanceController.AddBalance(IncomeCalculation(building));
                return;
            }
        }
    }
}