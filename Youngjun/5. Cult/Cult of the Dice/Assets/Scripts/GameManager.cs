using System.Collections;
using TMPro;
using UnityEngine;
public class GameManager : MonoBehaviour
{

    public GameObject dicePrefab;
    public GameObject diceJointPrefab;
    public GameObject cultistFlagPrefab;
    public GameObject cultistPaladinPrefab;

    Vector2 cultistSpawnPosition = new Vector2(-13f, 0.75f);

    Vector2 newDicePos = new Vector2(9f, -4f);
    Vector2 diceJointBegins1 = new Vector2(-1.75f, -0.77f);
    Vector2 diceJointBegins2 = new Vector2(-0.17f, -1.6f);
    Vector2 diceJointDistance = new Vector2(3.1f, 1.6f);

    public TextMeshProUGUI textMeshProUGUI;

    public int single = 0;
    public int multiple = 0;
    public int water = 0;
    public int thunder = 0;
    public int earth = 0;
    public int flame = 0;

    public string highestElemental;

    GameObject[] cultistPattern1;
    GameObject[] cultistPattern2;
    GameObject[] cultistPattern3;
    GameObject[] cultistPattern4;
    GameObject[] cultistPattern5;

    GameObject[] currentPattern = new GameObject[10];
    int randomPatternNumber;
    int randomTypeNumber;
    int countPattern;

    void Start()
    {
        cultistPattern1 = new GameObject[] { cultistFlagPrefab, cultistFlagPrefab, cultistFlagPrefab, cultistFlagPrefab, cultistFlagPrefab, cultistFlagPrefab, cultistFlagPrefab, cultistFlagPrefab, cultistFlagPrefab, cultistFlagPrefab };
        cultistPattern2 = new GameObject[] { cultistFlagPrefab, cultistPaladinPrefab, cultistPaladinPrefab, cultistPaladinPrefab, cultistPaladinPrefab, cultistPaladinPrefab, cultistPaladinPrefab, cultistPaladinPrefab, cultistPaladinPrefab, cultistPaladinPrefab };
        cultistPattern3 = new GameObject[] { cultistFlagPrefab, cultistFlagPrefab, cultistFlagPrefab, cultistFlagPrefab, cultistFlagPrefab, cultistPaladinPrefab, cultistPaladinPrefab, cultistPaladinPrefab, cultistPaladinPrefab, cultistPaladinPrefab };
        cultistPattern4 = new GameObject[] { cultistFlagPrefab, cultistPaladinPrefab, cultistFlagPrefab, cultistPaladinPrefab, cultistFlagPrefab, cultistPaladinPrefab, cultistFlagPrefab, cultistPaladinPrefab, cultistFlagPrefab, cultistPaladinPrefab };
        cultistPattern5 = new GameObject[] { cultistFlagPrefab, cultistFlagPrefab, cultistPaladinPrefab, cultistPaladinPrefab, cultistPaladinPrefab, cultistFlagPrefab, cultistFlagPrefab, cultistPaladinPrefab, cultistPaladinPrefab, cultistFlagPrefab };


        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                if ((i < 2) || (i >= 2 && j >= 1) && !(i == 3 && j == 2) && !(i >= 2 && j == 1))
                {
                    CreateDiceJoints(diceJointBegins1, i, j);
                    CreateDiceJoints(diceJointBegins2, i, j);
                }
                
            }
        }

        CreateDiceJoints(diceJointBegins2, 2, 1);
        CreateDiceJoints(diceJointBegins2, 3, 2);

        StartCoroutine(SpawnCultistRoutine());
    }

    private void Update()
    {
        highestElemental = FindMaxValue();
    }

    void FixedUpdate()
    {
        GameObject[] diceObjects = GameObject.FindGameObjectsWithTag("Dice");
        int[] updateValue = new int[6];
        int[] getCountValue = new int[6];

        foreach (GameObject diceObject in diceObjects)
        {
            Dice dice = diceObject.GetComponent<Dice>();

            if (dice != null) 
            {
                getCountValue = CountValue(dice.myTopFace);
                for (int i = 0; i < updateValue.Length; i++)
                {
                    updateValue[i] += getCountValue[i];
                }

                getCountValue = CountValue(dice.myLeftFace);
                for (int i = 0; i < updateValue.Length; i++)
                {
                    updateValue[i] += getCountValue[i];
                }

                getCountValue = CountValue(dice.myRightFace);
                for (int i = 0; i < updateValue.Length; i++)
                {
                    updateValue[i] += getCountValue[i];
                }
            }
        }

        single = updateValue[0];
        multiple = updateValue[1];
        water = updateValue[2];
        thunder = updateValue[3];
        earth = updateValue[4];
        flame = updateValue[5];

        textMeshProUGUI.text = "single: " + single + "\n" +
                               "multiple: " + multiple + "\n" +
                               "water: " + water + "\n" +
                               "thunder: " + thunder + "\n" +
                               "earth: " + earth + "\n" +
                               "flame: " + flame + "\n";
    }

    public void newDice()
    {
        if (!CheckTagAtLocation("Dice", newDicePos)){
            Instantiate(dicePrefab, newDicePos, Quaternion.identity);
        }

    }

    int[] CountValue(string diceFace)
    {
        int[] counts = new int[6];

        switch (diceFace)
        {
            case "single":
                counts[0]++;
                break;
            case "multiple":
                counts[1]++;
                break;
            case "water":
                counts[2]++;
                break;
            case "thunder":
                counts[3]++;
                break;
            case "earth":
                counts[4]++;
                break;
            case "flame":
                counts[5]++;
                break;
        }

        return counts;
    }

    bool CheckTagAtLocation(string tag, Vector2 position)
    {
        GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag(tag);

        foreach (GameObject obj in objectsWithTag)
        {
            if (Vector2.Distance(obj.transform.position, position) < 0.1f)
            {
                return true;
            }
        }

        return false;
    }

    void CreateDiceJoints(Vector2 beginPosition, int ii, int jj)
    {
        Vector2 newDiceJointPos = new Vector2();
        newDiceJointPos.x = beginPosition.x - diceJointDistance.x * ii;
        newDiceJointPos.y = beginPosition.y - diceJointDistance.y * jj;
        
        Instantiate(diceJointPrefab, newDiceJointPos, Quaternion.identity);
    }

    IEnumerator SpawnCultistRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f); 

            if (countPattern == 0)
            {
                randomPatternNumber = Random.Range(1, 6);
                randomTypeNumber = Random.Range(0, 4);

                switch (randomPatternNumber)
                {
                    case 1:
                        currentPattern = cultistPattern1;
                        break;
                    case 2:
                        currentPattern = cultistPattern2;
                        break;
                    case 3:
                        currentPattern = cultistPattern3;
                        break;
                    case 4:
                        currentPattern = cultistPattern4;
                        break;
                    case 5:
                        currentPattern = cultistPattern5;
                        break;
                    default:
                        currentPattern = cultistPattern1;
                        break;
                }
            }
            
            if (countPattern < 10)
            {
                GameObject newCultist = Instantiate(currentPattern[countPattern], cultistSpawnPosition, Quaternion.identity);
                Cultist cultist = newCultist.GetComponent<Cultist>();

                cultist.myType = (Cultist.Type)randomTypeNumber;

                countPattern++;
            }
            else countPattern = 0;
        }
    }

    public string FindMaxValue()
    {
        int[] values = new int[] { water, earth, thunder, flame };
        string maxValue = "";
        int max = values[0];

        for (int i = 0; i < values.Length; i++)
        {
            if (values[i] > max)
            {
                max = values[i];
            }
        }

        for (int i = 0; i < values.Length; i++)
        {
            if (max == values[i]) 
            {
                if (i == 0) maxValue = "water";
                if (i == 1) maxValue = "earth";
                if (i == 2) maxValue = "thunder";
                if (i == 3) maxValue = "flame";
            }
        }

        return maxValue;
    }
}
