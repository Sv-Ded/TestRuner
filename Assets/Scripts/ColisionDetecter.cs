using System;
using UnityEngine;

public class ColisionDetecter : MonoBehaviour
{
    public event Action<IInteractableObject> InteractableObjectTriggered;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out IInteractableObject interactableObject))
        {
            InteractableObjectTriggered?.Invoke(interactableObject);
        }
    }
}
