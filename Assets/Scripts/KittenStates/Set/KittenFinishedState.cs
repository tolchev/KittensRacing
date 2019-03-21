using UnityEngine;

namespace Assets.Scripts.KittenStates
{
    class KittenFinishedState : KittenState
    {
        public float moveSpeed = 1.5f;

        public override void Handle()
        {
            Vector3 movement = Vector3.forward * moveSpeed * Time.deltaTime;

            if (context.charController.transform.position.z + movement.z > 150)
            {
                movement.z = context.charController.transform.position.z - 150;

                context.animator.SetBool("Walking", false);
                context.TransitionTo(new KittenNullState());

                Messenger.Broadcast(GameEvents.KittenStoped);
            }

            context.charController.Move(movement);
            Messenger<Transform>.Broadcast(GameEvents.KittenPositionForCamera, context.charController.transform);
        }
    }
}