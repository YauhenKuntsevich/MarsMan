using System.Collections;
using Configs;
using Models;
using TMPro;
using UI;
using UnityEngine;

namespace Views
{
    public class BuildingView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private BuildingPrefab _buildingPrefab;
        [SerializeField] private BuildingsConfigs _buildingsConfigs;
        
        
        [SerializeField] private TextMeshProUGUI _buildingNameText;
        [SerializeField] private TextMeshProUGUI _buildingLevelText;
        [SerializeField] private LevelUpButton _levelUpPrefab;
        [SerializeField] private UpgradeButton _upgradePrefab;
        [SerializeField] private RectTransform _content;
        [SerializeField] private RectTransform _content2;
        [SerializeField] private RectTransform _content3;

        private readonly BuildingController _buildingController = BuildingController.GetInstance();
        private UpgradeConfig _upgrade1;
        private UpgradeConfig _upgrade2;

        public void DrawBuilding(bool active, BuildingConfig building)
        {
            _buildingNameText.text = building.Name;
            _upgrade1 = building.Update1;
            _upgrade2 = building.Update2;
            
            if (active)
            {
                var levelUpInstance = Instantiate(_levelUpPrefab, _content);
                levelUpInstance.DrawLevel(building.Level, building.BasicCost, building.Name);
            
                if (building.Level > 0)
                {
                    var upgrade1Instance = Instantiate(_upgradePrefab, _content2);
                    var upgrade2Instance = Instantiate(_upgradePrefab, _content3);
                    upgrade1Instance.DrawUpgrade(_upgrade1);
                    upgrade2Instance.DrawUpgrade(_upgrade2);
                }
            }
        }


        private void Update()
        {
            foreach (var building in _buildingsConfigs.Buildings)
            {
                if (building.Level >= 1)
                {
                    DrawBuilding(true, building);
                    StartCoroutine(ChangeMoney(building));
                }
            }
        }

        private IEnumerator ChangeMoney(BuildingConfig building)
        {
            while (true)
            {
                var elapsedTime = 0f;
                while (elapsedTime < building.IncomeDelay)
                {
                    elapsedTime += Time.deltaTime;
                    //UpdateProgressBar();
                    yield return null;
                }

                BalanceModel.Money += _buildingController.IncomeCalculation(building);
            }
        }

        public void BusinessLevelUp(int level)
        {
            _levelText.text = level.ToString();
        }
    }
}