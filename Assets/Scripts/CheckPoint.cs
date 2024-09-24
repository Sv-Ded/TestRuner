using System;

public class CheckPoint : BaseInteractableObject
{
    public event Action CheckPointIsSet;

    public override void OnTrigered()
    {
        CheckPointIsSet?.Invoke();
    }
}
