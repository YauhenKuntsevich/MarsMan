using System.Collections;
using Configs;
using Controllers;
using Models;
using TMPro;
using UI;
using UnityEngine;

namespace Views
{
    public class BuildingView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _buildingNameText;
        [SerializeField] private TextMeshProUGUI _buildingLevelText;
        [SerializeField] private TextMeshProUGUI _buildingIncomeText;
        
        [SerializeField] private BuildingConfig _buildingConfig;
        [SerializeField] private LevelUpButton _levelUpPrefab;
        [SerializeField] private UpgradeButton _upgradePrefab;
        [SerializeField] private UpgradeButton _upgrade2Prefab;
        [SerializeField] private RectTransform _content;
        
        private readonly BuildingController _buildingController = BuildingController.GetInstance();
        private UpgradeConfig _upgrade1;
        private UpgradeConfig _upgrade2;
        
        public void DrawBuilding(BuildingConfig building)
        {
            _buildingLevelText.text = "LVL " + building._level;
            _buildingNameText.text = building._name;
            _buildingIncomeText.text = "Доход: " + _buildingController.IncomeCalculation(building);
            _upgrade1 = building._update1;
            _upgrade2 = building._update2;
        }

        private void Start()
        {
            DrawBuilding(_buildingConfig);
            
            var levelUpInstance = Instantiate(_levelUpPrefab, _content);
            levelUpInstance.DrawLevel(_buildingConfig);
            var upgrade1Instance = Instantiate(_upgradePrefab, _content);
            var upgrade2Instance = Instantiate(_upgrade2Prefab, _content);
            upgrade1Instance.DrawUpgrade(_upgrade1);
            upgrade2Instance.DrawUpgrade(_upgrade2);
                
            if (_buildingConfig._level >= 1)
            {
                StartCoroutine(ChangeMoney(_buildingConfig));
            }

        }

        private void Update()
        {
            DrawBuilding(_buildingConfig);
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
            if (building._level < 1)
            {
                yield return null;
            }

            while (true)
            {
                var elapsedTime = 0f;
                while (elapsedTime < building._incomeDelay)
                {
                    elapsedTime += Time.deltaTime;
                    yield return null;
                }

                BalanceModel.Money += _buildingController.IncomeCalculation(building);
            }
        }
    }
}