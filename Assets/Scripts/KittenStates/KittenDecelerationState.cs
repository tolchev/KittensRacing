using UnityEngine;

namespace Assets.Scripts.KittenStates
{
    class KittenDecelerationState : KittenState
    {
        private float speed;

        public KittenDecelerationState(float startSpeed)
        {
            speed = startSpeed;
        }

        public override void Handle(KittenContext context)
        {
            if (speed > 10)
            {
                speed -= 10 * Time.deltaTime;
                Vector3 movement = Vector3.forward * speed * Time.deltaTime;
                context.charController.Move(movement);
                Messenger<Transform>.Broadcast(GameEvents.KittenPosition, context.charController.transform);
            }
            else
            {
                context.animator.SetBool("Running", false);
                context.animator.SetBool("Walking", true);
                context.State = new KittenFinishedState();
            }
        }
    }
}