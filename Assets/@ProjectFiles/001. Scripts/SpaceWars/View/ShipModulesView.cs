using SpaceWars.Modules;
using SpaceWars.Ship;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceWars.View
{
   public class ShipModulesView : MonoBehaviour
   {
      [SerializeField] private SpaceShip ship;
      [SerializeField] private Text uiText;

      private void Awake()
      {
         if(ship != null)
            ship.OnModulesDataChanged += ModulesDataChanged;
      }

      private void ModulesDataChanged(SpaceShipModule[] modules)
      {
         uiText.text = "Модули:\n\n\n";
         foreach (var spaceShipModule in modules)
         {
            if(spaceShipModule != null)
               uiText.text += spaceShipModule.GetDescription() + "\n\n";
            else
               uiText.text += "Место свободно \n\n";
         
         }
      }
   }
}
