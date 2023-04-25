using System;
using System.Collections;
using Configs;
using Models;
using TMPro;
using UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

namespace Views
{
    public class BuildingView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _buildingNameText;
        [SerializeField] private TextMeshProUGUI _buildingLevelText;
        [SerializeField] private TextMeshProUGUI _buildingIncomeText;
        
        [SerializeField] private BuildingsConfigs _buildingsConfigs;
        [SerializeField] private LevelUpButton _levelUpPrefab;
        [SerializeField] private UpgradeButton _upgradePrefab;
        [SerializeField] private UpgradeButton _upgrade2Prefab;
        [SerializeField] private RectTransform _content;

        private readonly BuildingController _buildingController = BuildingController.GetInstance();
        private UpgradeConfig _upgrade1;
        private UpgradeConfig _upgrade2;
        
        public void DrawBuilding(BuildingConfig building)
        {
            _buildingLevelText.text = building.Level.ToString();
            _buildingNameText.text = building.Name;
            _buildingIncomeText.text = _buildingController.IncomeCalculation(building).ToString();
            _upgrade1 = building.Update1;
            _upgrade2 = building.Update2;

            var levelUpInstance = Instantiate(_levelUpPrefab, _content);
            levelUpInstance.DrawLevel(building.Level, building.BasicCost, building.Name);

            if (building.Level > 0)
            {
                var upgrade1Instance = Instantiate(_upgradePrefab, _content);
                var upgrade2Instance = Instantiate(_upgrade2Prefab, _content);
                upgrade1Instance.DrawUpgrade(_upgrade1);
                upgrade2Instance.DrawUpgrade(_upgrade2);
            }
        }

        private void Start()
        {
            foreach (var building in _buildingsConfigs.Buildings)
            {
                if (building.Level >= 1)
                {
                    DrawBuilding(building);
                    StartCoroutine(ChangeMoney(building));
                }
            }
        }

        // private void Update()
        // {
        //     foreach (var building in _buildingsConfigs.Buildings)
        //     {
        //         if (building.Level >= 1)
        //         {
        //             DrawBuilding(true, building);
        //         }
        //     }
        // }

        private IEnumerator ChangeMoney(BuildingConfig building)
        {
            if (building.Level < 1)
            {
                yield return null;
            }

            var elapsedTime = 0f;
            while (elapsedTime < building.IncomeDelay)
            {
                elapsedTime += Time.deltaTime;
                yield return null;
            }

            BalanceModel.Money += _buildingController.IncomeCalculation(building);
        }

        public void BuildingLevelUp(int level)
        {
            _buildingLevelText.text = level.ToString();
        }
    }
}