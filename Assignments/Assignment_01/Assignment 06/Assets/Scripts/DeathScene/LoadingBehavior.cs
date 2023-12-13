using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class LoadingBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI tmp;
    public int read = 0;
    public AudioSource auds;
    void Start()
    {

        //tmp = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            read += 1;
            auds.Play(0);
        }


        if (read == 0)
        {
            tmp.text = "21 “Not everyone who says to Me, ‘Lord, Lord,’ " +
                "will enter the kingdom of heaven, but only he who does the will of " +
                "My Father who is in heaven.";
        }
        else if (read == 1)
        {
            tmp.text = "22 Many will say to Me on that day, " +
                "‘Lord, Lord, have we not prophesied in Your name, " +
                "and driven out demons in Your name, and done many miracles in Your name?’";
        }
        else if (read == 2)
        {
            tmp.text = "23 And then I will declare to them publicly, " +
                "‘I never knew you; depart from Me, you who act wickedly.’";
        }
        else if (read >= 3)
        {
            if (!auds.isPlaying)
            {
                SceneManager.LoadScene("Main Room");
            }
        }
    }
}
