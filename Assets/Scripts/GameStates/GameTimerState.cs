﻿using System;

namespace Assets.Scripts.GameStates
{
    class GameTimerState : GameState
    {
        readonly DateTime start = DateTime.Now;

        public override void Handle(GameContext context)
        {
            if (DateTime.Now - start >= new TimeSpan(0, 0, 3))
            {
                Messenger.Broadcast(GameEvents.Start);
                context.State = new GameNullState();
            }
        }
    }
}