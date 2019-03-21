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
            float move = context.movementModel.GetMove();

            if (move >= 130)
            {
                Messenger<Transform>.Broadcast(GameEvents.KittenFinished, context.charController.transform);
                context.TransitionTo(new KittenDecelerationState(context.movementModel.LastSpeed));
            }

            Vector3 pos = context.charController.transform.position;
            context.charController.transform.position = new Vector3(pos.x, pos.y, move);
            Messenger<Transform>.Broadcast(GameEvents.KittenPositionForCamera, context.charController.transform);
        }
    }
}