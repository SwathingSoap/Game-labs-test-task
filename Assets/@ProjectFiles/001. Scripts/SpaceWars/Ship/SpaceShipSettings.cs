using UnityEngine;

namespace SpaceWars.Ship
{
    [CreateAssetMenu(menuName = "SpaceWars/ShipSettings", fileName = "SpaceShipSettings", order = 0)]
    public class SpaceShipSettings : ScriptableObject
    {
        public int HP = 100;
        public int ShieldMax = 80;
        public int ShieldReload = 1;
        public int WeaponSlots = 2;
        public int ModuleSlots = 2;
        
    }
}
