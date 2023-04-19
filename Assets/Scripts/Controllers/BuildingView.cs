using System;
using Configs;
using TMPro;
using UI;
using UnityEngine;

namespace Controllers
{
    public class BuildingView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _levelText;
        [SerializeField] private BuildingPrefab _buildingPrefab;
        
        private void Update()
        {
            CheckLevel();
        }

        private void CheckLevel()
        {
            
        }
    }
}