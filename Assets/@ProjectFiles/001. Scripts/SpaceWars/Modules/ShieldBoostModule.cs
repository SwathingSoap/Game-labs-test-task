using System;
using SpaceWars.Ship;
using UnityEngine;

namespace SpaceWars.Modules
{
    [CreateAssetMenu(menuName = "SpaceWars/Modules/ShieldBoost", fileName = "ShieldBoostModule", order = 0)]
    [Serializable]
    public class ShieldBoostModule: SpaceShipModule
    {

        public override string GetDescription()
        {
            return $"Увеличение максимального запаса щита на {Value}";
        }
        
        public override void ApplyModule(SpaceShip ship)
        {
            ship.HealthSystem.AddMaxShield(Value);
        }

      
    }
}