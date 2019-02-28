using System;
using UnityEngine;

namespace Assets.Scripts.KittenStates
{
    class KittenRunState : KittenState
    {
        readonly DateTime startDateTime;

        public KittenRunState()
        {
            startDateTime = DateTime.Now;
        }

        public override void Handle()
        {
            TimeSpan moveTime = DateTime.Now - startDateTime;
            float moveSpeed = context.movementModel.GetSpeed(moveTime);
            Vector3 movement = Vector3.forward * moveSpeed * Time.deltaTime;

            if (context.charController.transform.position.z + movement.z > 135)
            {
                Messenger<Transform>.Broadcast(GameEvents.KittenFinished, context.charController.transform);
                context.TransitionTo(new KittenDecelerationState(moveSpeed));
            }

            context.charController.Move(movement);
            Messenger<Transform>.Broadcast(GameEvents.KittenPosition, context.charController.transform);
        }
    }
}