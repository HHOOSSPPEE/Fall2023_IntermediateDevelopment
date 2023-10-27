using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameOver GameOver;
    int maxPoints = 0;
    // Start is called before the first frame update
    public void GameOverS()
    {
        GameOver.Setup(maxPoints);
    }
}
