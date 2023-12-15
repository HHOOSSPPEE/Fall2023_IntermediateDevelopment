using UnityEngine;

public class HitEffectScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 newPosition = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y, 0);
        transform.position = newPosition;
    }

    void Die()
    {
        Destroy(gameObject);
    }
}
