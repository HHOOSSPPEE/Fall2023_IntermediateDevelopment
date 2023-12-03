using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;

    private int score;

    private void Start()
    {
        NewGame();
    }

    private void NewGame()
    {
        SetScore(0);
        Newlevel();
    }

    private void Newlevel()
    {
        this.player.gameObject.SetActive(true);
    }

    private void SetScore(int score)
    {
        this.score = score;
    }

}
