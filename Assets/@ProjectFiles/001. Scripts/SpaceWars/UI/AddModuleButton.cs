using SpaceWars.Modules;
using SpaceWars.Ship;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceWars.UI
{
    public class AddModuleButton : MonoBehaviour
    {
        [SerializeField] private SpaceShipModule module;
        [SerializeField] private SpaceShip ship;

        private void Awake()
        {
            Button b = GetComponent<Button>();
            if (b != null)
            {
                b.onClick.AddListener(TryToAddModuleToShip);
            }
        }

        private void TryToAddModuleToShip()
        {
            ship.AddModule(module);
        }
    }
}
