using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Movement movement;
    private Timer timer;
    public ParticleSystem verticalTrail;
    public ParticleSystem horizontalTrail;

    [Range(0.1f, 0.3f)]
    public float slowMotionRate = 0.2f;

    private void Awake()
    {
        movement = GetComponent<Movement>();
      
      
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
        Time.timeScale = slowMotionRate;
        yield return new WaitForSecondsRealtime(1);
        Time.timeScale = 1f;
    }

}
