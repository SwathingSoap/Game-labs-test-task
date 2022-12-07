using System;
using SpaceWars.Ship;
using UnityEngine;

namespace SpaceWars.Modules
{
    
    [CreateAssetMenu(menuName = "SpaceWars/Modules/HealthBoost", fileName = "HealthBoostModule", order = 0)]
    [Serializable]
    public class HealthBoostModule: SpaceShipModule
    {
        public override string GetDescription()
        {
            return $"Увеличение максимального запаса здоровья на {Value}";
        }

        public override void ApplyModule(SpaceShip ship)
        {
            ship.HealthSystem.AddMaxHP(Value);
        }

      
    }
}