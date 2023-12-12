using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Willy : MonoBehaviour
{
    public DialogueTrigger trigger;
    public DialogueTrigger winTrigger;
    public DialogueTrigger loseTrigger;
    private PlayerController PC;
    // Start is called before the first frame update
    private void Start()
    {
        PC = FindObjectOfType<PlayerController>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            trigger.StartDialogue();

            if (PC != null)
            {
                if (PC.score >= 6)
                {
                    winTrigger.StartDialogue();
                }
                else if (PC.score >0)
                {
                    loseTrigger.StartDialogue();
                }
            }
        }


    }
}
