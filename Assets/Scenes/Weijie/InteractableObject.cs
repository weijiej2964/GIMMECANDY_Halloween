using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{
    private bool z_Interacted = false;
    private bool z_DialogueComplete = false;
    public GameObject DialogueBox;
    private Dialogue dialogue;

    public string[] lines;

    
    protected override void OnCollided(GameObject collidedObject)
    {
        if(Input.GetKey(KeyCode.E))
        {
            OnInteract();
        }
    }

    private void OnInteract()
    {
        if(!z_Interacted)
        {
            DialogueBox.SetActive(true);
            dialogue = DialogueBox.GetComponent<Dialogue>();
            dialogue.setLines(lines);
            dialogue.setInteractableObject(this);
            dialogue.StartDialogue();
            z_Interacted = true; 
        }
        

    }

    public void SetCompleted(bool z)
    {
        z_DialogueComplete = z;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!z_DialogueComplete)
        {
            DialogueBox.SetActive(false);
            z_Interacted = false;
        }
       
    }

}
