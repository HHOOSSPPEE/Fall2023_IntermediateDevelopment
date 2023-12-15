using UnityEngine;

public class NightmareIncoming : MonoBehaviour
{
    public float direction;
    void Start()
    {
        transform.localScale = new Vector3(direction, 1, 1);
    }
    void Call()
    {
        NightmareController nightmare = FindObjectOfType<NightmareController>();
        nightmare.currentState = NightmareState.Teleport;
    }

    void Die()
    {
        Destroy(gameObject);    
    }

}
