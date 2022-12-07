using System;
using SpaceWars.Ship;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceWars.Fight
{
    public class SpaceShipFightSystem : MonoBehaviour
    {
        [SerializeField] private Transform[] weaponVisualSlots = new Transform[6];
        private SpaceShipWeapon[] weapons;
        
        public void InitializeSlots(int weaponsCount)
        {
            if (weaponsCount > weaponVisualSlots.Length)
            {
                Debug.LogError("Попытка инициализировать количество слотов вооружения больше, чем максимально" +
                               " возможно на данном корабле");
            }
            
            weapons = new SpaceShipWeapon[weaponsCount];
        }

        public void ActivateFightSystem(SpaceShip newTarget)
        {
            foreach (var spaceShipWeapon in weapons)
            {
                if (spaceShipWeapon != null)
                {
                    spaceShipWeapon.ActivateWeapon(newTarget);
                    spaceShipWeapon.Active = true;
                }
            }
        }
        
        public bool AddWeapon(SpaceShipWeaponSettings newWeaponSettings)
        {
            for (var i = 0; i < weapons.Length; i++)
            {
                if (weapons[i] == null)
                {
                    weapons[i] = SpaceShipWeapon.GenerateNewWeapon(newWeaponSettings,weaponVisualSlots[i]);
                    return true;
                }
            }

            return false;
        }

        public void RemoveLastWeapon()
        {
            for (int i = weapons.Length-1; i >= 0 ; i--)
            {
                if (weapons[i] != null)
                {
                    Destroy(weapons[i].gameObject);
                    weapons[i] = null;
                    return;
                }
            }
        }

        public void ReduceShootTime(int persent)
        {
            foreach (var spaceShipWeapon in weapons)
            {
                if (spaceShipWeapon != null)
                {
                    spaceShipWeapon.ReduceShootTime(persent);
                }
            }
        }



    }
}
