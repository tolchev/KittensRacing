using Assets.Scripts.KittenStates;
using System;

namespace Assets.Scripts.MovementModels
{
    class SimpleMovementModel : IMovementModel
    {
        public float GetSpeed(TimeSpan time)
        {
            return 15;
        }
    }
}