using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinball : MonoBehaviour
{
    private Rigidbody2D _rb;
    public float trailWidthMultiplier = 0.1f;
    private TrailRenderer _trailRenderer;
    public KeyCode controllKey = KeyCode.LeftArrow;
    public float torqueScale = 10.0f;
    private GameManager gameManager;
    public Vector3 spawnPosition;
    public AudioClip sound;
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = transform.position;
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        _trailRenderer = GetComponent<TrailRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        gameObject.SetActive(false);
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        audioSource.clip = sound;
        audioSource.Play();
        switch (collision.gameObject.tag) //to add points
        {
            case "Bumper":
                gameManager.AddScore(100);
                break;
            case "Kicker":
                gameManager.AddScore(200);
                break;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision) //almost only for kill zone
    {
        switch (collision.gameObject.tag)
        {
            case "Kill Zone": // end this round
                gameManager.EndRound();
                transform.position = spawnPosition;
                _rb.velocity = Vector2.zero;
                _rb.angularVelocity = 0;
                _trailRenderer.Clear();
                gameObject.SetActive(false);
                break;
        }
    }
}
