using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : CollidableObject
{
    private bool z_Interacted = false;
    private bool z_DialogueComplete = false;
    private Dialogue dialogue;

    public Canvas canvas; 
    public GameObject DialogueBox;
    private GameObject newDialogueObject;
    public string[] lines;

    public Candy CandyScore; 
    public int CandyReward;

    [SerializeField] private AudioSource ExitDialogueSFX; 


    protected override void OnCollided(GameObject collidedObject)
    {
        if(Input.GetKey(KeyCode.E))
        {
            OnInteract();
        }
    }

    private void OnInteract()
    {
        if (!z_Interacted)
        {
            newDialogueObject = Instantiate(DialogueBox, new Vector3(0,300f,0f), Quaternion.identity);
            newDialogueObject.transform.SetParent(canvas.transform, false);
            newDialogueObject.transform.localScale = Vector3.one;
            newDialogueObject.SetActive(true);
            dialogue = newDialogueObject.GetComponent<Dialogue>();

            dialogue.setLines(lines);
            dialogue.setInteractableObject(this.gameObject.GetComponent<InteractableObject>());

            dialogue.StartDialogue();
            z_Interacted = true;
        }


    }


    public void SetCompleted(bool z)
    {
        z_DialogueComplete = z;
        if(z == true)
        {
            CandyScore.IncreaseCandyAmount(CandyReward);
            CandyScore.UpdateCandyAmount();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!z_DialogueComplete)
        {
            ExitDialogueSFX.Play();
            newDialogueObject.SetActive(false);
            z_Interacted = false;
        }
       
    }

}
