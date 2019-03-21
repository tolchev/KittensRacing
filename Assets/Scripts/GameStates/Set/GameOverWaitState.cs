using System;

namespace Assets.Scripts.GameStates
{
    class GameOverWaitState : GameState
    {
        public GameOverWaitState()
        {
            Messenger.AddListener(GameEvents.GameOver, OnKittenStopedEvent);
        }

        private void OnKittenStopedEvent()
        {
            Messenger.RemoveListener(GameEvents.GameOver, OnKittenStopedEvent);
            context.TransitionTo(new GameOverState());
        }

        public override void Handle() { }
    }
}