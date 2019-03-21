namespace Assets.Scripts.GameStates
{
    class GameWaitGoToStartState : GameState
    {
        int count = 0;

        public GameWaitGoToStartState()
        {
            Messenger.AddListener(GameEvents.KittenOnStart, KittenOnStart);
        }

        public override void Handle()
        {
            if (count == 3)
            {
                context.TransitionTo(new GameTimerState());
                Messenger.RemoveListener(GameEvents.KittenOnStart, KittenOnStart);
            }
        }

        private void KittenOnStart()
        {
            count++;
        }
    }
}