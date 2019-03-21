namespace Assets.Scripts.KittenStates
{
    class KittenPrepareIthcingState : KittenPrepareState
    {
        bool isInit = false;

        public override void Handle()
        {
            if (!isInit)
            {
                isInit = true;
                context.animator.SetBool("Ithcing", true);
            }

            if (isStart && context.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle 0"))
            {
                context.animator.SetBool("Ithcing", false);
                context.animator.SetBool("Walking", true);
            }

            if (context.animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                context.TransitionTo(new KittenGoToStartState());
            }
        }
    }
}