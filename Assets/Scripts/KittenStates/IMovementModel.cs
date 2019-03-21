using System;

namespace Assets.Scripts.KittenStates
{
    interface IMovementModel
    {
        float GetMove();
        float LastSpeed { get; }
    }
}