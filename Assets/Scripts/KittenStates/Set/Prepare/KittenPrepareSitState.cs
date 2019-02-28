using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.KittenStates
{
    class KittenPrepareSitState : KittenPrepareState
    {
        bool isInit = false;

        void Init(KittenContext context)
        {
            isInit = true;
            context.animator.SetBool("Sitting", true);
        }

        public override void Handle()
        {
            if (!isInit)
            {
                Init(context);
            }

            if (isStart && context.animator.GetCurrentAnimatorStateInfo(0).IsName("IdleSitOnly"))
            {
                context.animator.SetBool("Sitting", false);
                context.animator.SetBool("Walking", true);
            }

            if (context.animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                context.TransitionTo(new KittenGoToStartState());
            }
        }
    }
}
