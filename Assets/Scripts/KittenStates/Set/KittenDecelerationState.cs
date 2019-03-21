using UnityEngine;

namespace Assets.Scripts.KittenStates
{
    class KittenDecelerationState : KittenState
    {
        private float curSpeed = 0;

        public KittenDecelerationState(float lastSpeed)
        {
            curSpeed = lastSpeed;
        }

        public override void Handle()
        {
            if (curSpeed > 3)
            {
                Vector3 pos = context.charController.transform.position;
                float z = Mathf.SmoothDamp(pos.z, 145, ref curSpeed, 1);
                pos = new Vector3(pos.x, pos.y, z);

                context.charController.transform.position = pos;
                Messenger<Transform>.Broadcast(GameEvents.KittenPositionForCamera, context.charController.transform);
            }
            else
            {
                context.animator.SetBool("Running", false);
                context.animator.SetBool("Walking", true);
                context.TransitionTo(new KittenFinishedState());
            }
        }
    }
}