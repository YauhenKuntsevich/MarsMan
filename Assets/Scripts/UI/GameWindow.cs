using System;
using UnityEngine;

namespace UI
{
    public class GameWindow : MonoBehaviour
    {
        [SerializeField] private BuildingPrefab _buildingPrefab;
        [SerializeField] private RectTransform _content;

        [SerializeField] private BuildingsConfigs _buildingsConfigs;

        private Balance _balance;

        private void Awake()
        {
            for (int i = 0; i < _buildingsConfigs.Buildings.Length; i++)
            {
                var buildingInstance = Instantiate(_buildingPrefab, _content);

                var buildingConfig = _buildingsConfigs.Buildings[i];
                
                // Здание активно, если
                // куплено предыдущее здание
                // ИЛИ оно первое
                bool active = 
                    ((i - 1 >= 0 && _buildingsConfigs.Buildings[i - 1].Level > 0) ||
                     i == 0) && 
                    _buildingsConfigs.Buildings[i].Level > 0;

                buildingInstance.DrawBuilding(
                    active,
                    _buildingsConfigs.Buildings[i]);
            }
        }
    }
}