using System;
using SpaceWars.Ship;
using UnityEngine;

namespace SpaceWars.Modules
{
    [Serializable]
    public abstract class SpaceShipModule: ScriptableObject
    {
        public int Value;
        public abstract string GetDescription();
        public abstract void ApplyModule(SpaceShip ship);
      
    }
}