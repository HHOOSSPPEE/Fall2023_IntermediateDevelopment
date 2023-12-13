using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    public float timer;

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        SetTimer(12);
        Newlevel();
    }

    private void Newlevel()
    {
        this.player.gameObject.SetActive(true);
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
