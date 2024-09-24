public class Gate : BaseInteractableObject
{
    public bool TryOpen(int moneyCount)
    {
        if (moneyCount > Price)
        {
            OnTrigered();
            return true;
        }
        else
        {
            return false;
        }
    }

    public override void OnTrigered()
    {
        GetComponentInChildren<DoorAnimation>().OnTigger();
    }
}