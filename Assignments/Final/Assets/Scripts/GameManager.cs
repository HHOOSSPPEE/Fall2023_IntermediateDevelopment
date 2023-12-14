using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    private Timer timerr;
                    
    public float timer;

    [Range(0f, 2f)]
    public float speed = 1.0f;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        if(instance != null)
        {
            Destroy(instance);
        }
                               
    }
    private void Start()
    {

        NewGame();
    }

    private void NewGame()
    {
        SetTimer(12f);
        Newlevel();
    }

    private void Newlevel()
    {
        //this.player.gameObject.SetActive(true);
    }

    private void SetTimer(float timer)
    {
        this.timer = timer;
    }

    public void ItemPickedUp(Item item)
    {
        item.gameObject.SetActive(false);
        SetTimer(this.timer);
    }

}
