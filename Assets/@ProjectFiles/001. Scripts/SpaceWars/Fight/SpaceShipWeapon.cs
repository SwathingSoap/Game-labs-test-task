using System;
using SpaceWars.Ship;
using UnityEditor;
using UnityEngine;

namespace SpaceWars.Fight
{
    public class SpaceShipWeapon: MonoBehaviour
    {
        private SpriteRenderer renderer;
        
        private float shootTime;
        private float shootTimer;
        private int damage;

        private SpaceShip target;

        private SpaceShipWeaponSettings settings;

        public bool Active = false;

    
        
        private void Update()
        {
            if(!Active || target == null || !target.HealthSystem.IsAlive) return;
            
            if (shootTimer >= shootTime)
            {
                Shoot();
                shootTimer -= shootTime;
            }
            else
            {
                shootTimer += Time.deltaTime;
            }
        }

        private void Shoot()
        {
            Debug.Log($"Оружие {settings.Name} делает выстрел по {target.gameObject.name} c уроном {settings.Dmg}");
            target.RemoveHP(damage);
        }

        public void ReduceShootTime(int persent)
        {
            if (persent != 0)
                shootTime = shootTime - (float)(shootTime * (float)(persent / 100f));
        }

        public void SetNewSettings(SpaceShipWeaponSettings newSettings,SpriteRenderer renderer)
        {
            settings = newSettings;
            shootTime = newSettings.ShootSpeed;
            damage = newSettings.Dmg;
            if (renderer != null) renderer.sprite = newSettings.Sprite;
        }

        public void ActivateWeapon(SpaceShip newTarget)
        {
            target = newTarget;
        }
        
        
        public static SpaceShipWeapon GenerateNewWeapon(SpaceShipWeaponSettings settings, Transform parent)
        {
            GameObject go = new GameObject();
            go.transform.parent = parent;
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            SpaceShipWeapon weapon = go.AddComponent<SpaceShipWeapon>();
            weapon.SetNewSettings(settings,go.AddComponent<SpriteRenderer>());
            return weapon;
        }
      
    }
}