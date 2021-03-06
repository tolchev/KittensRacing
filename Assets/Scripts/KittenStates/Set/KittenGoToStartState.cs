﻿using UnityEngine;

namespace Assets.Scripts.KittenStates
{
    class KittenGoToStartState : KittenState
    {
        const float min = -130;
        const float max = 130;
        public float moveSpeed = 1.5f;

        public override void Handle()
        {
            Vector3 movement = Vector3.forward * moveSpeed * Time.deltaTime;

            if (context.charController.transform.position.z + movement.z > min)
            {
                // Разница, которую переступили.
                movement.z = Mathf.Abs(context.charController.transform.position.z + max);
                context.animator.SetBool("Walking", false);
                context.TransitionTo(new KittenReadyState());
                Messenger.Broadcast(GameEvents.KittenOnStart);
            }

            context.charController.Move(movement);
            Messenger<Transform>.Broadcast(GameEvents.KittenPositionForCamera, context.charController.transform);
        }
    }
}