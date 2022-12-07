using System;
using SpaceWars.Ship;
using UnityEngine;

namespace SpaceWars.Modules
{
    [CreateAssetMenu(menuName = "SpaceWars/Modules/ShieldReloadBoost", fileName = "ShieldReloadModule", order = 0)]
    [Serializable]
    public class ShieldReloadBoostModule: SpaceShipModule
    {
        
        public override string GetDescription()
        {
            return $"Уменьшение времени перезарядки щита на {Value}%";
        }
        public override void ApplyModule(SpaceShip ship)
        {
            ship.HealthSystem.ReduceShieldReloadTime(Value);
        }

      
    }
}