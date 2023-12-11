using UnityEngine;

public class NightmareController : MonoBehaviour
{
    [HideInInspector] public float i_hp;
    [HideInInspector] public float hp;

    // Start is called before the first frame update
    void Start()
    {
        i_hp = 100f;
        hp = i_hp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage(float damage)
    {
        hp -= damage;
    }
}
