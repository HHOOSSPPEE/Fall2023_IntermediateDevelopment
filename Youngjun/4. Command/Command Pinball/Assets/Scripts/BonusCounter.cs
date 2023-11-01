using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BonusCounter : MonoBehaviour
{
    public string targetTag = "Player";
    public bool activated = false;
    private Color colorEnabled = new Color(1f, 1f, 1f, 1f);
    private Color colorDisabled = new Color(1f, 1f, 1f, 1f);

    private int point = 20;

    BoxCollider2D boxCollider2D;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider2D = GetComponent<BoxCollider2D>();

        spriteRenderer = GetComponent<SpriteRenderer>();

        colorEnabled.a = 0.01f;
        colorDisabled.a = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if (activated)
        {
            boxCollider2D.enabled = false;
            spriteRenderer.color = colorDisabled;
        }
        else
        {
            boxCollider2D.enabled = true;
            spriteRenderer.color = colorEnabled;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(targetTag))
        {
            GameManager gameManager = FindObjectOfType<GameManager>();
            if (gameManager != null)
            {
                gameManager.IncreaseScore(point);
                gameManager.bonusCounter1++;
                activated = true;
            }
        }
    }
}
