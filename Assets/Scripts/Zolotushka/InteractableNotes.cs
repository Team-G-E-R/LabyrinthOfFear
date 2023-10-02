using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableNotes : MonoBehaviour
{
    public UnityEvent InteractAction;
    
    public void Interact()
    {
        InteractAction.Invoke();
        Debug.Log("Interacted");
    }
}
