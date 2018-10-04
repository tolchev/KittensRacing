namespace Assets.Scripts.KittenStates
{
    abstract class KittenPrepareState : KittenState
    {
        protected bool isStart = false;

        public override void OnEvent(string evnt)
        {
            if (evnt == KittenContext.OnStart)
            {
                isStart = true;
            }
        }
    }
}