using SpaceWars.Ship;
using UnityEngine;
using UnityEngine.UI;

namespace SpaceWars.UI
{
   public class StartGameButton : MonoBehaviour
   {
      [SerializeField] private SpaceShip leftShip;
      [SerializeField] private SpaceShip rightShip;
      [SerializeField] private GameObject ui;
      private Button button;

      private void Awake()
      {
         button = GetComponent<Button>();
         if (button != null)
         {
            button.onClick.AddListener(StarGame);
         }
      }

      private void StarGame()
      {
         leftShip.StarShip(rightShip);
         rightShip.StarShip(leftShip);
         ui.gameObject.SetActive(false);
      }
   }
}
