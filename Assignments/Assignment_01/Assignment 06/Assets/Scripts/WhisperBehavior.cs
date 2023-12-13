using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhisperBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource auds;
    private bool complete = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (!auds.isPlaying && !complete)
            {
                auds.Play(0);
                complete = true;
            }
            else if (!auds.isPlaying && complete)
            {
                Destroy(gameObject);
            }
        }
    }
}
