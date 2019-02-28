namespace Assets.Scripts.KittenStates
{
    class KittenPrepareStandState : KittenPrepareState
    {
        public override void Handle()
        {
            if (isStart)
            {
                context.animator.SetBool("Walking", true);
                context.TransitionTo(new KittenGoToStartState());
            }
        }
    }
}