using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    private int timer;

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        SetTimer(10);
        Newlevel();
    }

    private void Newlevel()
    {
        this.player.gameObject.SetActive(true);
    }

    private void SetTimer(int timer)
    {
        this.timer = timer;
    }

    public void ItemPickedUp(Item item)
    {
        item.gameObject.SetActive(false);
        SetTimer(this.timer);
    }

}
