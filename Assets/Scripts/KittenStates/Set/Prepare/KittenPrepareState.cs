namespace Assets.Scripts.KittenStates
{
    abstract class KittenPrepareState : KittenState
    {
        public KittenPrepareState()
        {
            Messenger.AddListener(GameEvents.PrepareStarting, PrepareStarting);
        }

        private void PrepareStarting()
        {
            isStart = true;
            Messenger.RemoveListener(GameEvents.PrepareStarting, PrepareStarting);
        }

        protected bool isStart = false;
    }
}