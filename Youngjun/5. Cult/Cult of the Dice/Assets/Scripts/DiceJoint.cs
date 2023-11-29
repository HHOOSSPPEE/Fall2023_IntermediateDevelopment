using UnityEngine;

public class DiceJoint : MonoBehaviour
{
    CircleCollider2D circleCollider;
    public int level = 0;

    SpriteRenderer spriteRenderer;
    Color initialColor;

    // Start is called before the first frame update
    void Start()
    {
        circleCollider = GetComponent<CircleCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialColor = spriteRenderer.color;
    }

    // Update is called once per frame
    void Update()
    {
        TestLevel();
    }

    void FixedUpdate()
    {
        if (!circleCollider.IsTouchingLayers())
        {
            level = 0;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (level == 0 &&
            Vector2.Distance(transform.position, collision.transform.position) < 0.2f)
        {
            level = 1;
        }
    }

    private void TestLevel()
    {
        switch (level)
        {
            case 0:
                spriteRenderer.color = initialColor;
                break;

            case 1:
                spriteRenderer.color = Color.yellow;
                break;

            case 2:
                spriteRenderer.color = Color.blue;
                break;
        }
    }
}
