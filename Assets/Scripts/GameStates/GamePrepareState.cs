using UnityEngine;

namespace Assets.Scripts.GameStates
{
    class GamePrepareState : GameState
    {
        public override void Handle(GameContext context)
        {
            if (Input.GetButtonDown("Jump"))
            {
                Messenger.Broadcast(GameEvents.PrepareStarting);
                context.State = new GameWaitGoToStart();
            }
        }
    }
}