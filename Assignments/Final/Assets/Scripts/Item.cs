using UnityEngine;
using UnityEngine.SceneManagement;

public class Item : MonoBehaviour
{
    public int SceneNumber;
    private void Pickup()
    {
        Destroy(gameObject);
        Timer.instance.ResetTime();
        SceneManager.LoadScene(SceneNumber);

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Player")) {
            Pickup();
        }
    }

}
