using System;
using UnityEngine;

namespace Assets.Scripts.KittenStates
{
    class KittenContext
    {
        public readonly CharacterController charController;
        public readonly Animator animator;
        public readonly IMovementModel movementModel;

        public KittenContext(KittenState state, CharacterController charController, Animator animator, IMovementModel movementModel, string name)
        {
            TransitionTo(state);
            this.charController = charController;
            this.animator = animator;
            this.movementModel = movementModel;
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
    }
}