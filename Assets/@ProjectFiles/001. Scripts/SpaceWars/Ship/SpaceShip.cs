using System;
using SpaceWars.Fight;
using SpaceWars.Modules;
using UnityEngine;

namespace SpaceWars.Ship
{
    
    /// <summary>
    /// В этом задании я был нацелен сделать гибкую архитектуру для вооружения и модулей космического корабля
    ///     по этому интерфейс выглядит не очень красиво, как в плане визуала, так и кода. На сколько я могу судить,
    ///     интерфейс в этой задаче - не главное.
    /// </summary>
    
    public class SpaceShip : MonoBehaviour
    {
        public event Action<SpaceShipModule[]> OnModulesDataChanged = delegate(SpaceShipModule[] shipModules) {  };
        
        [SerializeField] private SpaceShipSettings settings;
        [SerializeField] private SpaceShipModule[] modules;
        
        public SpaceShipHealthSystem HealthSystem;
        public SpaceShipFightSystem FightSystem;
        
        private void Start()
        {
            HealthSystem.Initialize(settings);
            HealthSystem.OnDie += Die;
            
            modules = new SpaceShipModule[settings.ModuleSlots];
            OnModulesDataChanged?.Invoke(modules);
            FightSystem.InitializeSlots(settings.WeaponSlots);
        }
        
        public void StarShip(SpaceShip newTarget)
        {
            newTarget.HealthSystem.OnDie += TargetDie;
            ApplyModules();
            FightSystem.ActivateFightSystem(newTarget);
        }
        

        private void ApplyModules()
        {
            foreach (var spaceShipModule in modules)
            {
                if (spaceShipModule != null)
                {
                    spaceShipModule.ApplyModule(this);
                }
            }
        }

        private void Die()
        {
            gameObject.SetActive(false);
            Debug.Log($"Корабль {gameObject.name} взорван.");
        }

        private void TargetDie() => Debug.Log($"Корабль {gameObject.name} победил в сражении.");
        
        
        public void RemoveHP(int value) => HealthSystem.RemoveHP(value);
        public bool AddWeapon(SpaceShipWeaponSettings weaponSettings) => FightSystem.AddWeapon(weaponSettings);
        public void RemoveLastWeapon() => FightSystem.RemoveLastWeapon();
        public bool AddModule(SpaceShipModule module)
        {
            for (var i = 0; i < modules.Length; i++)
            {
                if (modules[i] == null)
                {
                    modules[i] = module;
                    OnModulesDataChanged?.Invoke(modules);
                    return true;
                }
            }

            return false;
        }
        
        public void RemoveLastModule()
        {
            for (int i = modules.Length-1; i >= 0 ; i--)
            {
                if (modules[i] != null)
                {
                    modules[i] = null;
                    OnModulesDataChanged?.Invoke(modules);
                    return;
                }
            }
        }

       
    }
}
