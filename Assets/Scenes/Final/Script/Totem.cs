using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Totem : InteractableObject
{
    public List<InteractableObject> Interactables; 
    public override void SetCompleted(bool z)
    {
        if (z)
        {
            foreach (var interactable in Interactables)
            {
                interactable.SetCompleted(false);
            }
        }

    }
}
