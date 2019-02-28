using UnityEngine;

namespace Assets.Scripts.GameStates
{
    class GamePrepareState : GameState
    {
        public override void Handle()
        {
            if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1"))
            {
                // Посылаем котам команду идти к старту.
                Messenger.Broadcast(GameEvents.PrepareStarting);
                context.TransitionTo(new GameWaitGoToStart());
            }
        }
    }
}