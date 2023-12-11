using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Willy : MonoBehaviour
{
    public DialogueTrigger trigger;
    // Start is called before the first frame update
   private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")==true)
        {
            trigger.StartDialogue();
        }
        
        
    }
}
