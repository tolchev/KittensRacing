namespace Assets.Scripts.KittenStates
{
    class KittenPrepareIthcingState : KittenPrepareState
    {
        bool isInit = false;
        bool wasJump = false;

        void Init(KittenContext context)
        {
            isInit = true;
            context.animator.SetBool("Ithcing", true);
        }

        public override void Handle()
        {
            if (!isInit)
            {
                Init(context);
            }

            if (!wasJump)
            {
                wasJump = isStart;
            }

            if (wasJump && context.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle 0"))
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