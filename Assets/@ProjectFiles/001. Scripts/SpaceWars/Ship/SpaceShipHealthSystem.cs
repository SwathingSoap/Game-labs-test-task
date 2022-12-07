using System;
using UnityEngine;

namespace SpaceWars.Ship
{
    [Serializable]
    public class SpaceShipHealthSystem : MonoBehaviour
    {
        public event Action<int> OnDamage = delegate { };
        public event Action<int> OnShieldValueChange = delegate { };
        public event Action OnDie = delegate { };
        public event Action OnInitialize = delegate {  };
        
        [SerializeField] private int defaultMaxShield = 80;
        [SerializeField] private int defaultHPValue = 100;
        [SerializeField] private float defaultReloadTime = 1;

        public bool IsAlive => HP > 0;

        private int maxHP;
        private int HP;
        private int maxShield;
        private int shield;

        private int shieldReloadSpeed = 1;
        private float timer = 0;
        private float reloadTime = 1;

        public int MaxHP => maxHP;
        public int MaxShield => maxShield;
        public float ReloadTime => reloadTime;
        public float ReloadTimer => timer;

        public void Initialize(SpaceShipSettings settings)
        {
            defaultMaxShield = settings.ShieldMax;
            defaultHPValue = settings.HP;
            defaultReloadTime = settings.ShieldReload;

            maxShield = defaultMaxShield;
            shield = maxShield;
            reloadTime = defaultReloadTime;
            timer = 0;
            maxHP = defaultHPValue;
            HP = maxHP;
            OnInitialize?.Invoke();
        }

        public void RemoveHP(int value)
        {
            if (shield > 0)
            {
                shield -= value;
                if (shield < 0)
                {
                    value = shield.Abs();
                    shield = 0;
                }
                else
                    value = 0;
                
                OnShieldValueChange?.Invoke(shield);
            }
            
            
            HP -= value;
            OnDamage?.Invoke(HP);

            if (HP <= 0)
            {
                HP = 0;
                OnDie?.Invoke();
            }
        }

        private void Update()
        {
            if (IsAlive && shield < maxShield)
            {
                if (timer >= reloadTime)
                {
                    shield += shieldReloadSpeed;
                    timer -= reloadTime;
                    OnShieldValueChange?.Invoke(shield);
                }
                else
                {
                    timer += Time.deltaTime;
                }
            }
        }
        
        
        #region Modules

        public void AddMaxShield(int buff)
        {
            maxShield += buff;
            shield = maxShield;
            OnInitialize?.Invoke();
        }   
        
        public void ReduceShieldReloadTime(int buff)
        {
            if (buff > 0)
            {
                reloadTime = reloadTime - (float) (reloadTime * (float) (buff / 100f));
            }

            timer = 0;
            OnInitialize?.Invoke();
        }

        public void AddMaxHP(int buff)
        {
            maxHP += buff;
            HP = maxHP;
            OnInitialize?.Invoke();
            
        }
        
        #endregion
        
        

    }
}