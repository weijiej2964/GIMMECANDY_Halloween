using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI TextComponent;
    public float TextSpeed;
    public ControlPlayer player; 

    private GameObject interactableObject;
    private int _index;
    private string[] Lines;

    [SerializeField] private AudioSource textPopSFX; 


    // Start is called before the first frame update
    void Start()
    { 
        player = GameObject.Find("playerSprite").GetComponent<ControlPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.death)
        {
            Destroy(gameObject);
        }

        if (Input.GetMouseButtonDown(0) || Input.GetKey(KeyCode.E))
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
            textPopSFX.Play();
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
            interactableObject.GetComponent<InteractableObject>().SetCompleted(true);
            Destroy(gameObject);
        }
    }

    public void setLines(string[] lines)
    {
        Lines = lines;

    }

    public void setInteractableObject(GameObject obj)
    {
        interactableObject = obj;
    }



}
