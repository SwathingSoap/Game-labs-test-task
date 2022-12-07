using SpaceWars.Fight;
using SpaceWars.Ship;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceWars.UI
{
   public class AddWeaponButton : MonoBehaviour
   {
      [SerializeField] private SpaceShipWeaponSettings settings;
      [SerializeField] private SpaceShip ship;

      private void Awake()
      {
         Button b = GetComponent<Button>();
         if (b != null)
         {
            b.onClick.AddListener(TryToAddWeaponToShip);
         }
      }

      private void TryToAddWeaponToShip()
      {
         ship.AddWeapon(settings);
      }
   }
}
