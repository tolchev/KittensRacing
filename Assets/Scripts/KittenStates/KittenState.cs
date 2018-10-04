namespace Assets.Scripts.KittenStates
{
    abstract class KittenState
    {
        public abstract void Handle(KittenContext context);
        public virtual void OnEvent(string evnt) { }
    }
}