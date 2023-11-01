using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    public string targetTag = "Player";
    public bool type;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                if (type)
                {
                    gameManager.IncreaseScore(1);
                }
                else gameManager.IncreaseScore(100);
            }
        }
    }
}
