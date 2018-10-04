namespace Assets.Scripts.KittenStates
{
    class KittenPrepareStandState : KittenPrepareState
    {
        public override void Handle(KittenContext context)
        {
            if (isStart)
            {
                context.animator.SetBool("Walking", true);
                context.State = new KittenGoToStartState();
            }
        }
    }
}