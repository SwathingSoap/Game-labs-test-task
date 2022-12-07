using SpaceWars.Ship;
using UnityEngine;

namespace SpaceWars.View
{
   public class HealthView : MonoBehaviour
   {
      [SerializeField] private SpaceShipHealthSystem healthSystem;
      [SerializeField] private Transform healthBar;
      [SerializeField] private Transform shieldBar;
      [SerializeField] private Transform shieldRelBar;

      private float healthDelta;
      private float shieldDelta;
      private float shieldRelDelta;

      private void Awake()
      {
         healthSystem.OnDamage += OnDamage;
         healthSystem.OnShieldValueChange += OnShieldValueChange;
         healthSystem.OnInitialize += OnInitialize;
      }

      private void OnInitialize()
      {
         healthDelta = healthBar.localScale.x / healthSystem.MaxHP;
         shieldDelta = shieldBar.localScale.x / healthSystem.MaxShield;
         shieldRelDelta = shieldRelBar.localScale.x / healthSystem.ReloadTime;
      }

      private void Update()
      {
         var scale = shieldRelBar.localScale;
         scale.x = healthSystem.ReloadTimer * shieldRelDelta;
         shieldRelBar.localScale = scale;
      }

      private void OnDamage(int value)
      {
         var scale = healthBar.localScale;
         scale.x = value * healthDelta;
         healthBar.localScale = scale;
      } 
   
      private void OnShieldValueChange(int value)
      {
         var scale = shieldBar.localScale;
         scale.x = value * shieldDelta;
         shieldBar.localScale = scale;
      }
   }
}
