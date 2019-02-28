using System;

namespace Assets.Scripts.GameStates
{
    abstract class GameState
    {
        protected GameContext context;

        public void SetContext(GameContext context)
        {
            this.context = context;
        }

        public abstract void Handle();
    }
}