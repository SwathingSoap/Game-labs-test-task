using System;
using SpaceWars.Ship;
using UnityEngine;

namespace SpaceWars.Modules
{
    
    [CreateAssetMenu(menuName = "SpaceWars/Modules/WeaponReloadBoost", fileName = "ReloadWeaponBoostModule", order = 0)]
    [Serializable]
    public class ReloadWeaponsBoost: SpaceShipModule
    {

        public override string GetDescription()
        {
            return $"Ускорение перезарядки оружия на {Value}";
        }

        public override void ApplyModule(SpaceShip ship)
        {
            ship.FightSystem.ReduceShootTime(Value);
        }

      
    }
}