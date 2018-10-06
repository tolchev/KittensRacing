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
            State = state;
            this.charController = charController;
            this.animator = animator;
            this.movementModel = movementModel;

            Messenger.AddListener(GameEvents.PrepareStarting, PrepareStarting);
        }

        public KittenState State { get; set; }

        public void Request()
        {
            State.Handle(this);
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