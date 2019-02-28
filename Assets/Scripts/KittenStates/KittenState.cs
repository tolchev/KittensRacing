namespace Assets.Scripts.KittenStates
{
    abstract class KittenState
    {
        protected KittenContext context;

        public void SetContext(KittenContext context)
        {
            this.context = context;
        }

        public abstract void Handle();

        public virtual void OnEvent(string evnt) { }
    }
}