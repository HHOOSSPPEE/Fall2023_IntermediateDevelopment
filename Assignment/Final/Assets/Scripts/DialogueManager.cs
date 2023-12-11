using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Image actorImage;
    public TextMeshProUGUI actorName;
    public TextMeshProUGUI messageText;
    public Image backgoundBox;
    public Image Avatar;
    
    Message[] currentMessages;
    Actor[] currentActors;
    int activeMessage = 0;

    public static bool isActive = false;

    public void OpenDialogue(Message[] messages, Actor[] actors)
    {
        currentMessages = messages;
        currentActors = actors;
        activeMessage = 0;
        isActive = true;
        Debug.Log("Started Conversation!" + messages.Length);
        DisplayMessage();
        backgoundBox.color = new Color(1f, 1f, 1f, 1f);
        Avatar.color = new Color(1f, 1f, 1f, 1f);
        actorName.color = new Color(86f, 22f, 13f, 235f);
        messageText.color = new Color(86f, 22f, 13f, 235f);
    }

    void DisplayMessage()
    {
        Message messageToDisplay = currentMessages[activeMessage];
        messageText.text = messageToDisplay.message;

        Actor actorToDisplay = currentActors[messageToDisplay.actorId];
        actorName.text = actorToDisplay.name;
        actorImage.sprite = actorToDisplay.sprite;

    }

    public void NextMessage()
    {
        activeMessage++;
        if(activeMessage< currentMessages.Length)
        {
            DisplayMessage();
        }
        else
        {
            Debug.Log("Conversation end");
            backgoundBox.color = new Color(1f, 1f, 1f, 0f);
            Avatar.color = new Color(1f, 1f, 1f, 0f);
            actorName.color = new Color(1f, 1f, 1f, 0f);
            messageText.color = new Color(1f, 1f, 1f, 0f);
            isActive = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        backgoundBox.color = new Color(1f, 1f, 1f, 0f);
        Avatar.color = new Color(1f, 1f, 1f, 0f);
        actorName.color = new Color(1f, 1f, 1f, 0f);
        messageText.color = new Color(1f, 1f, 1f, 0f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isActive==true)
        {
            NextMessage();
        }
    }
}
