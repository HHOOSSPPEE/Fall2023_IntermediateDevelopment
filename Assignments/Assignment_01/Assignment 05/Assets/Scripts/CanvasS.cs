using System.Collections;
using System.Collections.Generic;
using Fungus;
using UnityEngine;

public class CanvasS : MonoBehaviour
{
    // Start is called before the first frame update
    public GameManager c;
    public Sprite spr;
    public Sprite spr1;
    void Start()
    {

         c = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
       int play = GameManager.gamesComplete;
       if (play == 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spr;
        }
       if (play == 2)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spr1;
        }
    }
}
