using System;
using UnityEngine;

namespace Assets.Scripts.KittenStates
{
    class KittenContext : IDisposable
    {
        public const string OnStart = "OnStart";

        public readonly CharacterController charController;
        public readonly Animator animator;
        public readonly IMovementModel movementModel;

        public KittenContext(KittenState state, CharacterController charController, Animator animator, IMovementModel movementModel, string name)
        {
            TransitionTo(state);
            this.charController = charController;
            this.animator = animator;
            this.movementModel = movementModel;

            Messenger.AddListener(GameEvents.PrepareStarting, PrepareStarting);
        }

        public KittenState State { get; private set; }

        public void Request()
        {
            State.Handle();
        }

        public void TransitionTo(KittenState state)
        {
            State = state;
            state.SetContext(this);
        }

        private void PrepareStarting()
        {
            State.OnEvent(OnStart);
        }

        public void Dispose()
        {
            Messenger.RemoveListener(GameEvents.PrepareStarting, PrepareStarting);
        }
    }
}