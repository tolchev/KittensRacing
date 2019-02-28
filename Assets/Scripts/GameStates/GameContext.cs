namespace Assets.Scripts.GameStates
{
    class GameContext
    {
        public GameContext(GameState state)
        {
            TransitionTo(state);
        }

        public GameState State { get; private set; }

        public void Request()
        {
            State.Handle();
        }

        public void TransitionTo(GameState state)
        {
            State = state;
            state.SetContext(this);
        }
    }
}
