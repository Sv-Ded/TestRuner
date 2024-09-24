using UnityEngine;

public abstract class BaseInteractableObject:MonoBehaviour, IInteractableObject
{
    [field: SerializeField] public int Price { get; private set; }

    public virtual void OnTrigered()
    {
        gameObject.SetActive(false);
    }
}
