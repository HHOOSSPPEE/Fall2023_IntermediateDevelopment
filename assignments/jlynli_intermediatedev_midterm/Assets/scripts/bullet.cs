using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Vector2 velocity;
    public float speed;
    public float rotation;

    [SerializeField]
    Transform player;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, 0, rotation);
        player = GameObject.Find("player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(velocity * speed * Time.deltaTime);

        //distance to player
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer > 10)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            Destroy(gameObject);
        }
    }
}
