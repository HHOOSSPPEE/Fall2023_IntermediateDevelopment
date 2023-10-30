using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score {  get; private set; } = 0;
    [SerializeField] private List<TextMeshProUGUI> highScoreSlotList = new List<TextMeshProUGUI>();
    private List<int> highScoreList = new List<int>();
    private GameObject _pinball;
    private TextMeshProUGUI _currentScoreTMP;
    [SerializeField] private GameObject _pinballPrefab;
    [SerializeField] private TextMeshProUGUI _timePanelTMP;
    public KeyCode leftFlipperControllKey;
    public KeyCode rightFlipperControllKey;
    public KeyCode plungerControllKey;
    private AudioListener _audioListener;

    [SerializeField] private GameObject startGameButton;
    public bool testing = true;
    void Start()
    {
        _currentScoreTMP = GameObject.Find("Score Panel").GetComponentInChildren<TextMeshProUGUI>();
        _pinball = GameObject.Find("Pinball");
        for (int i = 0; i < highScoreSlotList.Count; i++)
            highScoreList.Add(-1); //huh? what is this? what i was writing for?
        highScoreList[0] = 500;
        UpdateHighScore();
        _audioListener = GetComponent<AudioListener>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log((float)(score / 500f));
        _currentScoreTMP.text = "Score: " + score;
        _timePanelTMP.text = "Time Scale: " + Time.timeScale.ToString("0.00");
        Time.timeScale = 1f + (float)(score / (float)highScoreList[0]);



        _audioListener.velocityUpdateMode = AudioVelocityUpdateMode.Fixed;
        AudioListener.pause = false;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }
    public void StartRound()
    {
        score = 0;
        _pinball.SetActive(true);
        _pinball.transform.position = _pinball.GetComponent<Pinball>().spawnPosition;
        _pinball.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    public void EndRound()
    {
        UpdateHighScore();
        startGameButton.SetActive(true);
    }
    public void UpdateHighScore()
    {
        for (int i = 0; i < highScoreList.Count; i++) //update high score list
        {
            if (score > highScoreList[i])
            {
                highScoreList.Insert(i, score);
                highScoreList.RemoveAt(highScoreList.Count - 1);
                break;
            }
        }
        for (int i = 0;i < highScoreSlotList.Count;i++) //update text
        {
            if (highScoreList[i] < 0)
                highScoreSlotList[i].text = "0" + (i + 1) + ": --";
            else
                highScoreSlotList[i].text = "0" + (i+1) + ": " + highScoreList[i];
        }
        score = 0;
    }
}
