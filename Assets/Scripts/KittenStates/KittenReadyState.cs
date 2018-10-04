namespace Assets.Scripts.KittenStates
{
    class KittenReadyState : KittenState
    {
        bool isStart = false;

        public KittenReadyState()
        {
            Messenger.AddListener(GameEvents.Start, OnStart);
        }

        public override void Handle(KittenContext context)
        {
            if (isStart)
            {
                context.animator.SetBool("Running", true);
                context.State = new KittenRunState();
                Messenger.RemoveListener(GameEvents.Start, OnStart);
            }
        }

        private void OnStart()
        {
            isStart = true;
        }
    }
}