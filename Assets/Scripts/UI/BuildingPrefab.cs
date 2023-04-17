using System;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class BuildingPrefab : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _buildingNameText;
        [SerializeField] private TextMeshProUGUI _buildingLevelText;
        [SerializeField] private LevelUpButton _levelUpPrefab;
        [SerializeField] private UpgradeButton _upgradePrefab;
        [SerializeField] private RectTransform _content;
        [SerializeField] private RectTransform _content2;
        [SerializeField] private RectTransform _content3;

        private UpgradeConfig _upgrade1;
        private UpgradeConfig _upgrade2;

        public void DrawBuilding(bool active, BuildingConfig building)
        {
            _buildingNameText.text = building.Name;
            _buildingLevelText.text = building.Level.ToString();
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
        
        
    }
}