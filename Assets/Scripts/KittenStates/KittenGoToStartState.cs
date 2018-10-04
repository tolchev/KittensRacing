using UnityEngine;

namespace Assets.Scripts.KittenStates
{
    class KittenGoToStartState : KittenState
    {
        public float moveSpeed = 1.5f;

        public override void Handle(KittenContext context)
        {
            Vector3 movement = Vector3.forward * moveSpeed * Time.deltaTime;

            if (context.charController.transform.position.z + movement.z > -130)
            {
                movement.z = context.charController.transform.position.z + 130;

                context.animator.SetBool("Walking", false);
                context.State = new KittenReadyState();
                Messenger.Broadcast(GameEvents.KittenOnStart);
            }

            context.charController.Move(movement);
            Messenger<Transform>.Broadcast(GameEvents.KittenPosition, context.charController.transform);
        }
    }
}