namespace Assets.Scripts.GameStates
{
    class GameWaitGoToStart : GameState
    {
        int count = 0;

        public GameWaitGoToStart()
        {
            Messenger.AddListener(GameEvents.KittenOnStart, KittenOnStart);
        }


        public override void Handle(GameContext context)
        {
            if (count == 3)
            {
                context.State = new GameTimerState();
                Messenger.RemoveListener(GameEvents.KittenOnStart, KittenOnStart);
            }
        }

        private void KittenOnStart()
        {
            count++;
        }
    }
}