using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private Movement movement;
    private Timer timer;
    public ParticleSystem verticalTrail;
    public ParticleSystem horizontalTrail;

    [Range(0.1f, 0.3f)]
    public float slowMotionRate = 0.2f;

    //Player Color Change
    public Color newColor;
    public SpriteRenderer rend;

    private SoundManager soundManager;


    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();
        movement = GetComponent<Movement>();
        rend = GetComponent<SpriteRenderer>();   
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            movement.SetDirection(Vector2.up);
            verticalTrail.Play();
            transform.localRotation = Quaternion.Euler(180, 0, 0);

        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            movement.SetDirection(Vector2.down);
            verticalTrail.Play();
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            movement.SetDirection(Vector2.left);
            horizontalTrail.Play();
            transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            movement.SetDirection(Vector2.right);
            horizontalTrail.Play();
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            
        }

        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(SlowMotionnSequence());
        }

        //if (Input.GetKey(KeyCode.Space))
        //{
        //    SlowMotion();
        //}
        //else
        //{
        //    NormalMotion();
        //}
    }

  

   


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Wall")
        {
            ScreenShake.instance.TriggerShake(0.2f, 0.5f);
            //Timer.instance.TimerReset();
            Debug.Log("WallTouched");
        }
    }

    //private void SlowMotion()
    //{
    //    Time.timeScale = Mathf.Lerp(1, 0.15f, 5f);
    //    //ScreenShake.instance.TriggerShake(0f, 0f);
    //}

    //private void NormalMotion()
    //{
    //    Time.timeScale = Mathf.Lerp(0.15f, 1f, 5f);
        
    //}

    public IEnumerator SlowMotionnSequence()
    {
        //Gamestate turns slow
        Time.timeScale = slowMotionRate;
        //Player goes invisible
        rend.color = newColor;
        //Waits for a second
        yield return new WaitForSecondsRealtime(1);
        //Gamestate returns back to normal speed
        Time.timeScale = 1f;
        //Player returns to normal color;
        rend.color = Color.white;
        //Timer is deduced
        Timer.instance.time -= Time.deltaTime * 5;
    }

}
