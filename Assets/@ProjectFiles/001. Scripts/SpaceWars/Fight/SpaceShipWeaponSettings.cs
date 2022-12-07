using UnityEngine;

namespace SpaceWars.Fight
{
    [CreateAssetMenu(menuName = "SpaceWars/Wepons", fileName = "SpaceShipWeapon", order = 0)]
    public class SpaceShipWeaponSettings: ScriptableObject
    {
        public int ShootSpeed = 1;
        public int Dmg = 1;

        public string Name = "LaserGun";
        public Sprite Sprite;
    }
}