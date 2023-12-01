using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyLineofSight : MonoBehaviour
{
    //PLAYER REFERENCE
    public player player;
    //[SerializeField] public float respawnX = 36.04f;
    //[SerializeField] public float respawnY = 0.57f;
    //[SerializeField] public float respawnZ = 0f;
    public string SceneName;
    private void Start()
    {
        player = GetComponent<player>();
    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Player") && player.instance.invisible == false)
        {
            //player.instance.transform.position = new Vector3(respawnX, respawnY, respawnZ);
            SceneManager.LoadScene(SceneName);
                
        }
       
     
    }
}
