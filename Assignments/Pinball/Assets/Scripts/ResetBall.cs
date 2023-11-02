using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetBall : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Ball;
    [SerializeField ]private int maxLives = 3;
    private int currentLives;
    public AudioSource dead;

    private void Start()
    {
        currentLives = maxLives;    
    }


    public void Dead()
    {
        currentLives--;
        if (currentLives <= 0)
        {
            SceneManager.LoadScene("GameOverr");
            Debug.Log("GameOver");
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        Dead();
        Ball.position = new Vector3(2.97f, -4.38f, 0f);
        Debug.Log("Dead");
        dead.Play();

    }

   
}
