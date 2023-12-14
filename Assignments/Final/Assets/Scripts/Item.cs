using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    public static Item Instance;
    public int SceneNumber;
    [SerializeField] private AudioSource itemSFX;

    private void Awake()
    {
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }


    private void Pickup()
    {
        itemSFX.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider2D>().enabled = false;
        gameObject.GetComponent <Animator>().enabled = false;
        SceneManager.LoadScene(SceneNumber);
        Destroy(gameObject, 1f);
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            Pickup();
        }
    }

}
