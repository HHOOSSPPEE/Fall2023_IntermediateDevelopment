using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.UIElements;
//using UnityEditor.Experimental.GraphView;

public class TextBoxBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI tmp;
    public GameObject textbox;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Text Box")
        {
            textbox.GetComponent<SpriteRenderer>().enabled = true;
            if (collision.gameObject.GetComponent<PromptText>().selfNum == 1)
            {
                tmp.text = "The end is here. " +
                    "I must bless this desecrated ground for the souls to rise to Heaven.";
            }
            if (collision.gameObject.GetComponent<PromptText>().selfNum == 2)
            {
                tmp.text = "The first angel sounded his trumpet, " +
                    "and there came hail and fire mixed with blood, and " +
                    "it was hurled down on the earth. ";
            }
            if (collision.gameObject.GetComponent<PromptText>().selfNum == 3)
            {
                tmp.text = "The second angel sounded his trumpet, " +
                    "and something like a huge mountain, all ablaze, " +
                    "was thrown into the sea. A third of the sea turned into blood ";
            }
            if (collision.gameObject.GetComponent<PromptText>().selfNum == 4)
            {
                tmp.text = "The third angel blew his trumpet, " +
                    "and a great star fell from heaven, " +
                    "and it fell on a " +
                    "third of the rivers and on the springs of water.";
            }
            if (collision.gameObject.GetComponent<PromptText>().selfNum == 5)
            {
                tmp.text = "And in those days people will seek death " +
                    "and will not find it. They will long to die, but death will flee from them.";
            }
            if (collision.gameObject.GetComponent<PromptText>().selfNum == 6)
            {
                tmp.text = "Do not think that I have come to bring peace to the earth. " +
                    "I have not come to bring peace, but a sword. ";
            }
            if (collision.gameObject.GetComponent<PromptText>().selfNum == 7)
            {
                tmp.text = "If your hand or your foot causes you to sin, " +
                    "cut it off and throw it away. " +
                    "It is better for you to enter life maimed" +
                " than to have two hands or two feet and be thrown into eternal fire.";
            }
            if (collision.gameObject.GetComponent<PromptText>().selfNum == 8)
            {
                tmp.text = "They cried, but there was none to save them: " +
                    "even unto the LORD, but he answered them not.";
            }
            if (collision.gameObject.GetComponent<PromptText>().selfNum == 9)
            {
                tmp.text = "The fourth angel blew his trumpet, " +
                    "and a third of the sun was struck, and a third of the moon, " +
                    "and a third of the stars, so that a third of their light might be darkened";
            }
            if (collision.gameObject.GetComponent<PromptText>().selfNum == 10)
            {
                tmp.text = "The fifth angel sounded his trumpet, " +
                    "When he opened the Abyss, smoke rose." +
                    " And out of the smoke locusts came down on the earth and were given power like that " +
                    "of scorpions of the earth.";
            }
            





        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Text Box")
        {
            tmp.text = "";
            textbox.GetComponent<SpriteRenderer>().enabled = false;
            Destroy(collision.gameObject);
           
        }
    }
}
