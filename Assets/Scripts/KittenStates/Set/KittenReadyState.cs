namespace Assets.Scripts.KittenStates
{
    class KittenReadyState : KittenState
    {
        bool isStart = false;

        public KittenReadyState()
        {
            Messenger.AddListener(GameEvents.Start, OnStart);
        }

        public override void Handle()
        {
            if (isStart)
            {
                context.animator.SetBool("Running", true);
                context.TransitionTo(new KittenRunState());
                Messenger.RemoveListener(GameEvents.Start, OnStart);
            }
        }

        private void OnStart()
        {
            isStart = true;
        }
    }
}