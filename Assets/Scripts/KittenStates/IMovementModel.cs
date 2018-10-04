using System;

namespace Assets.Scripts.KittenStates
{
    interface IMovementModel
    {
        float GetSpeed(TimeSpan time);
    }
}