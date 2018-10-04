namespace Assets.Scripts.GameStates
{
    abstract class GameState
    {
        public abstract void Handle(GameContext context);
    }
}