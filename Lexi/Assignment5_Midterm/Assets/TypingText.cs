using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TypingText : MonoBehaviour
{


    public TextMeshProUGUI textUI;
    public Image hint;
    public Image star;
    public GameObject[] displayObjects;
    private GameObject[] o_displayObjects;
    private string currentText = "";
    //public string[] keywords;

    public Draw drawScript;

    public void Start()
    {
        o_displayObjects = displayObjects;
        StartCoroutine(WaitAndHideText(10f));


    }

    IEnumerator WaitAndHideText(float waitTime)
    {
        // 等待指定时间
        yield return new WaitForSeconds(waitTime);

        // 在等待时间后执行操作
        HideText();
    }

    void HideText()
    {
        // 将文本设置为空或者禁用 TextMeshProUGUI 组件，具体操作取决于你的需求
        // yourText.text = ""; // 设置文本为空
        star.enabled = false; // 禁用 TextMeshProUGUI 组件
    }


    void CheckPlayerInput()
    {
        // 检查玩家是否有输入
        if (Input.GetMouseButton(0) )
        {
            // 玩家有输入，不禁用 Image 组件
            hint.enabled = true;
        }
        else
        {
            // 玩家没有输入，禁用 Image 组件
            hint.enabled = false;
        }
    }

    void Update()
    {
        drawScript = FindObjectOfType<Draw>();
        // 在这里获取正在打字的文字（你可以根据你的需求获取输入的文字）
        CheckPlayerInput();



        string userInput = Input.inputString;
        
        if (userInput.Contains("5"))
        {
            drawScript.Pen_Width = 4; 
        }

        if (userInput.Contains("4"))
        {
            drawScript.Pen_Width = 4; 
        }
        if (userInput.Contains("3"))
        {
            drawScript.Pen_Width = 3; 
        }
        if (userInput.Contains("2"))
        {
            drawScript.Pen_Width = 2; 
        }
        if (userInput.Contains("1"))
        {
            drawScript.Pen_Width = 1; 
        }
        if (userInput.Contains("6"))
        {
            drawScript.Pen_Width = 6; 
        }
        if (userInput.Contains("7"))
        {
            drawScript.Pen_Width = 7;
        }
        if (userInput.Contains("8"))
        {
            drawScript.Pen_Width = 8;
        }
        if (userInput.Contains("9"))
        {
            drawScript.Pen_Width = 9;
        }
        if (userInput.Contains("RED"))
        {
            drawScript.Pen_Colour = drawScript.Red_Pen_Colour;
        }

        

        // 检查是否按下回车键
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // 如果按下回车键，清空当前输入字符串
            currentText = "";
        }
        else if (Input.GetKeyDown(KeyCode.Backspace) && currentText.Length > 0)
        {
            // 删除最后一个字符
            currentText = currentText.Substring(0, currentText.Length - 1);
        }
        else
        {

            currentText += userInput;
            GameObject[] ORANGEObjects = GameObject.FindGameObjectsWithTag("ORANGE");
            GameObject[] GREENObjects = GameObject.FindGameObjectsWithTag("GREEN");
            GameObject[] PURPLEObjects = GameObject.FindGameObjectsWithTag("PURPLE");
            GameObject[] AMETHYSTObjects = GameObject.FindGameObjectsWithTag("AMETHYST");
            GameObject[] COPPERObjects = GameObject.FindGameObjectsWithTag("COPPER");
            GameObject[] CORNObjects = GameObject.FindGameObjectsWithTag("CORN");
            GameObject[] AQUAObjects = GameObject.FindGameObjectsWithTag("AQUA");
            GameObject[] GREYObjects = GameObject.FindGameObjectsWithTag("GREY");
            GameObject[] GRASSObjects = GameObject.FindGameObjectsWithTag("GRASS");
            GameObject[] CERISEObjects = GameObject.FindGameObjectsWithTag("CERISE");
            GameObject[] REDObjects = GameObject.FindGameObjectsWithTag("RED");
            GameObject[] BLUEObjects = GameObject.FindGameObjectsWithTag("BLUE");
            GameObject[] YELLOWObjects = GameObject.FindGameObjectsWithTag("YELLOW");
            if (currentText.ToLower() == "red")
            {
                drawScript.Pen_Colour = drawScript.Red_Pen_Colour;
                
            }
            else if (currentText.ToLower() == "blue")
            {
                drawScript.Pen_Colour = drawScript.Blue_Pen_Colour;
            }
            else if (currentText.ToLower() == "yellow")
            {
                drawScript.Pen_Colour = drawScript.Yellow_Pen_Colour;
            }
            else if (currentText.ToLower() == "white")
            {
                drawScript.Pen_Colour = drawScript.White_Pen_Colour;
            }
            foreach (GameObject obj in displayObjects)
            {
                if (currentText.ToLower().Contains(obj.name.ToLower()))
                {

                    if (currentText.ToLower().Contains("orange".ToLower()) && obj.name == null)
                    {
                        Debug.Log("OOps");
                    }
                    if (obj.CompareTag("ORANGE"))
                    {
                        drawScript.Pen_Colour = drawScript.Orange_Pen_Colour;
                    }
                    else if (obj.CompareTag("GREEN"))
                    {
                        drawScript.Pen_Colour = drawScript.Green_Pen_Colour;
                    }
                    else if (obj.CompareTag("PURPLE"))
                    {
                        drawScript.Pen_Colour = drawScript.Purple_Pen_Colour;
                    }
                    else if (obj.CompareTag("AMETHYST"))
                    {
                        drawScript.Pen_Colour = drawScript.Amethyst_Pen_Colour;
                    }
                    else if (obj.CompareTag("COPPER"))
                    {
                        drawScript.Pen_Colour = drawScript.Copper_Pen_Colour;
                    }
                    else if (obj.CompareTag("AQUA"))
                    {
                        drawScript.Pen_Colour = drawScript.Aqua_Pen_Colour;
                    }
                    else if (obj.CompareTag("GREY"))
                    {
                        drawScript.Pen_Colour = drawScript.Grey_Pen_Colour;
                    }
                    else if (obj.CompareTag("CORN"))
                    {
                        drawScript.Pen_Colour = drawScript.Corn_Pen_Colour;
                    }
                    else if (obj.CompareTag("GRASS"))
                    {
                        drawScript.Pen_Colour = drawScript.Grass_Pen_Colour;
                    }
                    else if (obj.CompareTag("CERISE"))
                    {
                        drawScript.Pen_Colour = drawScript.Cerise_Pen_Colour;
                    }


                }

                foreach (GameObject o_obj in o_displayObjects)
                {
                    if (currentText.ToLower().Contains(o_obj.name.ToLower()))
                    {
                        o_obj.SetActive(true);
                    }
                    else o_obj.SetActive(false);
                }
            }
        }


        // 更新UI Text的文本内容为当前输入的字符串
        textUI.text = currentText;
    }
}
