namespace Assets.Scripts.GameStates
{
    class GameContext
    {
        public GameState State { get; set; }

        public void Request()
        {
            State.Handle(this);
        }
    }
}
