using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    public int SceneNumber;
    private SoundManager soundManager;

    private void Awake()
    {
        soundManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<SoundManager>();  
    }

    private void Pickup()
    {
        soundManager.PlaySFX(soundManager.item);
        SceneManager.LoadScene(SceneNumber);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            Pickup();
        }
    }

}
