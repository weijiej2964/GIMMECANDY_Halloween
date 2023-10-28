using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI TextComponent;
    private string[] Lines;
    public float TextSpeed;

    private InteractableObject interactableObject;

    private int _index;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (Lines != null && TextComponent.text == Lines[_index])
            {
                StopAllCoroutines();
                NextLine();
            }
        }
    }

    public void StartDialogue()
    {
        _index = 0;
        TextComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in Lines[_index].ToCharArray()) 
        {
            TextComponent.text += c;
            yield return new WaitForSeconds(TextSpeed); 
            
        }
    }

    void NextLine()
    {
        if(_index < Lines.Length - 1)
        {
            _index++;
            TextComponent.text = string.Empty;
            StartCoroutine(TypeLine()); 
        }
        else
        {
            interactableObject.SetCompleted(true);
            Destroy(gameObject); 

        }
    }

    public void setLines(string[] lines)
    {
        Lines = lines;

    }

    public void setInteractableObject(InteractableObject obj)
    {
        interactableObject = obj;
    }


}
