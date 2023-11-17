using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Fungus;
using UnityEngine.SceneManagement;
using static UnityEditor.PlayerSettings;

public class GameManager : MonoBehaviour
{
    public static List<ItemData> collectedItems = new List<ItemData>();
    static float moveSpeed = 5f, moveAccuracy = 0.15f;

    public static GameManager instance;
    public static int gamesComplete = 0;
    public static bool fish = false;
    public static bool desk = false;
    public Sprite newSprite;
    public Sprite normal;

    public SpriteRenderer spriteRenderer;
    [Header("Set Up")]
    public AnimationData[] playerAnimations;
    public RectTransform nameTag, hintBox, toDoList;

    [Header("Local Scenes")]
    public Image blockingImage;
    public GameObject[] localScenes;
    int activeLocalScene = 0;
    public Transform[] playerStartPositions;

    [Header("Equipment")]
    public GameObject equipmentCanvas;
    public Image[] equipmentSlots, equipmentImages;
    public Sprite emptyItemSlotSprite;
    public Color selectedItemColor;
    public int selectedCanvasSlotID = 0, selectedItemId = -1;


    [Header("Gardening")]
    public TileManager tileManager;
    public CubeGardening cube;
    public bool wateringFull = false;

    private ItemData itm;

    //public Vector2 posPlayer;

    //i was going to put this but then it messed all the mini games up - i just kept the static variables as is tbh
    //private void Awake()
    //{
    //    if (instance != null && instance != this)
    //    {
    //        Destroy(this.gameObject);
    //    }
    //    else
    //    {
    //        instance = this;
    //    }

    //    DontDestroyOnLoad(this.gameObject);


    //}

   

    public IEnumerator MoveToPoint(Transform myObject, Vector2 point)
    {
        //FindObjectOfType<ClickManager>().playerWalking = true;
        Vector2 positionDifference = point - (Vector2)myObject.position; //set direction

        if (myObject.GetComponentInChildren<SpriteRenderer>() && positionDifference.x != 0)
        {
            myObject.GetComponentInChildren<SpriteRenderer>().flipX = positionDifference.x < 0;
        }
                while (positionDifference.magnitude > moveAccuracy)
        {
            myObject.Translate(moveSpeed * positionDifference.normalized * Time.deltaTime);
            positionDifference = point - (Vector2)myObject.position;
            //Animator animator = myObject.GetComponentInChildren<SpriteRenderer>().sprite = new Sprite("walk");
                //myObject.GetComponent<Sprite>();
            yield return null;
        }

        //Animator walk = gameObject.GetComponentInChildren<Animator>(); //place this instead of the bird sprite
        //walk.SetBool("walk", true);

        //if (FindObjectOfType<ClickManager>().playerWalking)
        //{
        //    spriteRenderer.sprite = newSprite;
        //}
        //else
        //{
        //    spriteRenderer.sprite = normal;
        //}
    
        myObject.position = point;
        if (myObject == FindObjectOfType<ClickManager>().player)
        {
            FindObjectOfType<ClickManager>().playerWalking = false;
        }

        yield return null;
        
        //stop
    }

    public void SelectItem(int equipmentCanvasID)
    {
        Color c = Color.white;
        c.a = 0;
        //here it like checks if its empty so it doesnt crash the game 
        if (equipmentCanvasID >= collectedItems.Count || equipmentCanvasID < 0)
        {
            selectedItemId = -1;
            selectedCanvasSlotID = 0;
            return;
        }
        equipmentSlots[selectedCanvasSlotID].color = c;
        equipmentSlots[equipmentCanvasID].color = selectedItemColor;
        //saves it at the end 
        selectedCanvasSlotID = equipmentCanvasID;
        selectedItemId = collectedItems[selectedCanvasSlotID].itemID;
    }

    public void ShowItemName(int equipmentCanvasID)
    {
        if (equipmentCanvasID < collectedItems.Count)
        {
            UpdateNameTag(collectedItems[equipmentCanvasID]);
            
        }
    }

    public void Update()
    {
        int itemsAmount = collectedItems.Count, itemSlotsAmount = equipmentSlots.Length;

        for (int i = 0; i< itemSlotsAmount; i++)
        {
            if (i < itemsAmount && collectedItems[i].itemSlotSprite != null)
            {
                equipmentImages[i].sprite = collectedItems[i].itemSlotSprite;
            }
            else
            {
                equipmentImages[i].sprite = emptyItemSlotSprite;
            }
        }

        if (itemsAmount == 0)
            SelectItem(-1);
        else if (itemsAmount == 1)
            SelectItem(0);

        //complete check
        GameObject[] flr = GameObject.FindGameObjectsWithTag("Flower");
            if (gamesComplete == 2 && flr.Length > 7)
            {
            SceneManager.LoadScene("CompleteGame");
            }
    }


    public void UpdateNameTag(ItemData item)
    {
        nameTag.GetComponentInChildren<TextMeshProUGUI>().text = item.objectName;
        nameTag.sizeDelta = item.nameTagSize;
        nameTag.localPosition = new Vector2(item.nameTagSize.x/2, -0.5f);
    }

    public void UpdateToDoList(ItemData item)
    {
        
        toDoList.GetComponentInChildren<TextMeshProUGUI>().text = item.toDoList;
        toDoList.sizeDelta = item.toDoListSize;
        toDoList.localPosition = new Vector2(item.toDoListSize.x / 2, -0.5f);

    }

    //public void UpdateHintBox(ItemData item, bool playerFlipped)
    //{
    //    if (item == null)
    //    {
    //        hintBox.gameObject.SetActive(false);
    //        return;
    //    }
    //    hintBox.gameObject.SetActive(true);

    //    hintBox.GetComponentInChildren<TextMeshProUGUI>().text = item.hintMessage;
    //    hintBox.sizeDelta = item.hintBoxSize;
    //    if (playerFlipped)
    //        hintBox.parent.localPosition = new Vector2(-1, 0);
    //    else
    //        hintBox.parent.localPosition = Vector2.zero;
    //}


    public void CheckSpecialConditions(ItemData item)
    {
        switch (item.itemID)
        {
            case -11:
                StartCoroutine(ChangeScene(0, 1));
                break;
            case -12:
                StartCoroutine(ChangeScene(1, 1));
                break;
            case -13:
                StartCoroutine(ChangeScene(2, 1));
                break;
            case -14:
                if (selectedItemId >= 25)
                {
                    //Debug.Log(item.name);
                    item.gameObject.GetComponent<CubeGardening>().emptyDirt = false;
                    item.gameObject.GetComponent<CubeGardening>().PlantNew(selectedItemId,item.gameObject);
                   

                    

                    foreach (ItemData tm in FindObjectsOfType<ItemData>())
                    {
                        if (tm.itemID == selectedItemId)
                        {
                            itm = tm;
                        }
                    }

                    collectedItems.Remove(itm);
                    Debug.Log(collectedItems.Count);
                    //Destroy(item);
                    //Debug.Log(collectedItems.Count);

                }
                break;
            case -15:
                //this is the water if watering can is activated - turn on public bool
                if (selectedItemId == 20)
                {
                    wateringFull = true;
                    Debug.Log("water full");
                }
                    break;
            case 15:
                Debug.Log("canclick");
                if (selectedItemId == 20 && wateringFull == true)
                {
                    Debug.Log("wateredPlant");
                    wateringFull = false;
                }
                break;


        }


    }

    public IEnumerator ChangeScene(int sceneNumber, float delay)
    {
        yield return new WaitForSeconds(delay);
        Color c = blockingImage.color;

        blockingImage.enabled = true;
        while(blockingImage.color.a < 1)
        {
            c.a += Time.deltaTime;
            blockingImage.color = c;
        }

        localScenes[activeLocalScene].SetActive(false);
        localScenes[sceneNumber].SetActive(true);
        activeLocalScene = sceneNumber;

        FindObjectOfType<ClickManager>().player.position = playerStartPositions[sceneNumber].position;

        //UpdateHintBox(null, false);

        foreach (SpriteAnimator spriteAnimator in FindObjectsOfType<SpriteAnimator>())
            
            spriteAnimator.PlayAnimation(null);
        

        while (blockingImage.color.a > 0)
        {
            c.a -= Time.deltaTime;
            blockingImage.color = c;
        }
        blockingImage.enabled = false;


        yield return null;
    }


    public void SceneSwitch(ItemData item)
    {
        
        if (item.itemID == 26 && !desk)
        {
            //transform.position = new Vector2(0, 0);
            gamesComplete += 1;
            desk = true;
            SceneManager.LoadScene("DeskCleanUpMini");
        }

        if (item.itemID == 27 && !fish)
        {
            //posPlayer = GameObject.FindGameObjectWithTag("Player").transform.position;
            //gameObject.SetActive(false);
            //equipmentCanvas.SetActive(false);
            gamesComplete += 1;
            fish = true;
            SceneManager.LoadScene("FeedingFish");
        }
    }
}
