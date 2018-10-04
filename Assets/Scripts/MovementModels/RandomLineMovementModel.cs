using Assets.Scripts.KittenStates;
using System;

namespace Assets.Scripts.MovementModels
{
    class RandomLineMovementModel : IMovementModel
    {
        readonly float firstSpeed;
        readonly float secondSpeed;
        readonly int cutPointMiliseconds;

        public RandomLineMovementModel(float firstSpeed, float negativeDeltaSpeed, float positiveDeltaSpeed, int fullSeconds)
        {
            this.firstSpeed = firstSpeed;
            secondSpeed = UnityEngine.Random.Range(firstSpeed - Math.Abs(negativeDeltaSpeed), firstSpeed + Math.Abs(positiveDeltaSpeed));
            cutPointMiliseconds = (int)UnityEngine.Random.Range(fullSeconds * 0.1f, fullSeconds * 0.9f) * 1000;
        }

        public float GetSpeed(TimeSpan time)
        {
            return time.TotalMilliseconds < cutPointMiliseconds ? firstSpeed : secondSpeed;
        }
    }
}