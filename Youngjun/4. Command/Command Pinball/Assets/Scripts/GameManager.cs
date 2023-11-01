using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public string scoreText;
    public TextMeshProUGUI targetText;

    private bool isSpacePressed = false;
    private bool isLeftShiftPressed = false;
    private bool isRightShiftPressed = false;

    public TextMeshProUGUI commandText;
    private bool isTyping = false;
    private string command = "";
    private string commandCircles = "SRLRLS";
    private string commandPanels = "SLRRLS";
    private string commandTriangles = "SLRLRS";

    private int bonusMultiplier = 2;
    public int bonusCounter1 = 0;
    public int bonusCounter2 = 0;

    void Start()
    {

    }

    void Update()
    {
        commandText.text = command;

        if (command.Length > 6)
        {
            command = "";
        }

        if (Input.GetKeyDown(KeyCode.Space) && !isSpacePressed)
        {
            command += "S";
            if (isTyping)
            {
                CheckCommand();
            }
            else isTyping = true;

            isSpacePressed = true;
        }

        if (Input.GetKeyUp(KeyCode.Space) && isSpacePressed)
        {
            isSpacePressed = false;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isLeftShiftPressed)
        {
            command += "L";
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && isLeftShiftPressed)
        {
            isLeftShiftPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.RightShift) && !isRightShiftPressed)
        {
            command += "R";
        }

        if (Input.GetKeyUp(KeyCode.RightShift) && isRightShiftPressed)
        {
            isRightShiftPressed = true;
        }

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Restart();
        }
    }

    public void FixedUpdate()
    {
        if (bonusCounter1 == 5)
        {
            score *= bonusMultiplier;
            IncreaseScore(0);
            ResetBonus("Bonus1");
        }
    }

    public void IncreaseScore(int number)
    {
        score += number;
        scoreText = "" + score;
        targetText.text = scoreText;
    }
    
    void CheckCommand()
    {
        SwitchController[] targetObjects = FindObjectsOfType<SwitchController>();

        foreach (SwitchController targetObject in targetObjects)
        {
            if (targetObject != null)
            {
                if (command == commandCircles && targetObject.tag == "Circles")
                {
                    targetObject.activated = !targetObject.activated;
                }

                if (command == commandPanels && targetObject.tag == "Panels")
                {
                    targetObject.activated = !targetObject.activated;
                }

                if (command == commandTriangles && targetObject.tag == "Triangles")
                {
                    targetObject.activated = !targetObject.activated;
                }
            }
            
        }

        isTyping = false;
        command = "";
    }

    void ResetBonus(string bonusTag)
    {
        BonusCounter[] targetObjects = FindObjectsOfType<BonusCounter>();

        foreach (BonusCounter targetObject in targetObjects)
        {
            if (targetObject != null && targetObject.tag == bonusTag)
            {
                targetObject.activated = false;
            }

        }

        bonusCounter1 = 0;
    }

    public void Restart()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
}
