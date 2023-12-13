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
    bool StartdialogueOver = false;
    public DialogueManager DM;
    // Start is called before the first frame update
    private void Start()
    {
        PC = FindObjectOfType<PlayerController>();
        DM = FindObjectOfType<DialogueManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!StartdialogueOver)
            {
                trigger.StartDialogue();
                StartdialogueOver = true;
            }
            else if (PC != null)
            {
                if (PC.score >= 6)
                {
                    winTrigger.StartDialogue();
                    DM.CanFish = false;
                }
                else if (PC.score < 6)
                {
                    loseTrigger.StartDialogue();
                    DM.CanFish = false;
                }
            }
        }
    }
}
