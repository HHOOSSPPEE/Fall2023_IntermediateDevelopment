using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[RequireComponent(typeof(Rigidbody2D))]
public class BatEffect : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float lifeTime;
    [SerializeField] private float direction;
    [Tooltip("affect alpha")]
    [SerializeField] private AnimationCurve alpha;
    private float bornTime;
    private SpriteRenderer spriteRenderer;
    // Start is called before the first frame update
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        bornTime = Time.time;

        direction = UnityEngine.Random.Range(0f, 360f);
        if (direction > 90 && direction < 270)
            spriteRenderer.flipX = true;

            float radians = Mathf.Deg2Rad * direction;
        float velocityX = speed * Mathf.Cos(radians);
        float velocityY = speed * Mathf.Sin(radians);
        GetComponent<Rigidbody2D>().velocity = new Vector2(velocityX, velocityY);
    }

    // Update is called once per frame
    void Update()
    {
        float lifePhase = (Time.time - bornTime) / lifeTime;
        float lifeColor = alpha.Evaluate(lifePhase);
        spriteRenderer.color = new Color(lifeColor, lifeColor, lifeColor, lifeColor);

        Debug.Log(GetComponent<Rigidbody2D>().position);
        if (Time.time > bornTime + lifeTime)
        {
            Destroy(gameObject);
        }

    }
}
