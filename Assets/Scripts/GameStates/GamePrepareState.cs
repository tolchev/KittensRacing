using UnityEngine;

namespace Assets.Scripts.GameStates
{
    class GamePrepareState : GameState
    {
        public override void Handle(GameContext context)
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
            {
                Messenger.Broadcast(GameEvents.PrepareStarting);
                context.State = new GameWaitGoToStart();
            }
        }
    }
}